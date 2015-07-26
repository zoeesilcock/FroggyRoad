using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

    public float _smoothRotate;

    private Animator animator;
    private Quaternion sourceRotation;
    private Quaternion targetRotation;
    private float rotateStartTime;
    private bool waitingToJump;
    private bool jumping;

    void Start() {
        animator = transform.GetComponent<Animator>();
        targetRotation = transform.parent.rotation;
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
        } else if (waitingToJump) {
            animator.SetTrigger("Jump");
            waitingToJump = false;
        }
    }

    public void StartJump(float rotationY) {
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
}
