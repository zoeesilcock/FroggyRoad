using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

    public float _jumpForceY;
    public float _jumpForceX;

    private bool grounded;

    void Update() {
        if (Input.GetMouseButtonDown(0) && grounded) {
            gameObject.GetComponent<Rigidbody>().AddForce(_jumpForceX, _jumpForceY, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            grounded = false;
        }
    }
}
