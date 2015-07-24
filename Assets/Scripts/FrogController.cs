using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

    public float _jumpForceUp;
    public float _jumpForceForward;
    public float _smoothTurn;

    private bool grounded;
    private float targetRotationY;

    void Update() {
        if (Input.GetAxis("Vertical") > 0.0f && grounded) {
            Jump(_jumpForceForward, 0, 0);
        } else if (Input.GetAxis("Vertical") < 0.0f && grounded) {
            Jump(-_jumpForceForward, 0, 180);
        } else if (Input.GetAxis("Horizontal") < 0.0f && grounded) {
            Jump(0, _jumpForceForward, -90);
        } else if (Input.GetAxis("Horizontal") > 0.0f && grounded) {
            Jump(0, -_jumpForceForward, 90);
        }

        if (transform.rotation.y != targetRotationY) {
            Quaternion target = Quaternion.Euler(270, targetRotationY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smoothTurn);
        }
    }

    void Jump(float forceX, float forceZ, float rotation) {
        targetRotationY = rotation;
        gameObject.GetComponent<Rigidbody>().AddForce(forceX, _jumpForceUp, forceZ);
        grounded = false;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            grounded = true;
        }
    }
}
