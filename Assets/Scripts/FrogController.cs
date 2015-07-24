using UnityEngine;
using System.Collections;

public class FrogController : MonoBehaviour {

    public float _jumpForceY;
    public float _jumpForceX;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            gameObject.GetComponent<Rigidbody>().AddForce(_jumpForceX, _jumpForceY, 0.0f);
        }
    }
}
