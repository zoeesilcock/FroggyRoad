using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

    public float _smoothRotate;
    public string _layerName;

    private Animator animator;
    private Quaternion sourceRotation;
    private Quaternion targetRotation;
    private float rotateStartTime;
    private bool waitingToJump;
    private bool jumping;
    private bool alive;

    void Start() {
        animator = transform.GetComponent<Animator>();
        targetRotation = transform.parent.rotation;
        alive = true;
    }

    void Update() {
        if (Input.GetAxis("Vertical") > 0.0f && !jumping) {
            StartJump(0.0f);
        } else if (Input.GetAxis("Vertical") < 0.0f && !jumping) {
            StartJump(180.0f);
        } else if (Input.GetAxis("Horizontal") < 0.0f && !jumping) {
            StartJump(-90.0f);
        } else if (Input.GetAxis("Horizontal") > 0.0f && !jumping) {
            StartJump(90.0f);
        }

        if (Quaternion.Angle(transform.parent.rotation, targetRotation) > 0.4f) {
            transform.parent.rotation = Quaternion.Slerp(sourceRotation, targetRotation, (Time.time - rotateStartTime) / _smoothRotate);
        } else if (waitingToJump && alive) {
            if (!Physics.Raycast(transform.position, transform.right, 1, LayerMask.NameToLayer(_layerName))) {
                animator.SetTrigger("Jump");
                waitingToJump = false;
            } else {
                animator.SetTrigger("JumpFail");
                waitingToJump = false;
            }
        }
    }

    public void StartJump(float rotationY) {
        if (!alive)
            return;

        sourceRotation = transform.parent.rotation;
        targetRotation = Quaternion.Euler(270, rotationY, 0);
        rotateStartTime = Time.time;
        waitingToJump = true;
        jumping = true;
    }

    public void JumpEnded() {
        transform.parent.position = transform.position;
        transform.localPosition = Vector3.zero;
        jumping = false;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Car")) {
            StartCoroutine("Death");
        }
    }

    public IEnumerator Death() {
        animator.StopPlayback();

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.1f);
        transform.parent.position = new Vector3(transform.parent.position.x, 0.0f, transform.parent.position.z);

        alive = false;

        yield return new WaitForSeconds(5);

        Application.LoadLevel("MainScene");
    }
}
