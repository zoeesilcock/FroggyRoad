using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    public float _speed;

    void Start() {
        transform.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, _speed);
    }

    void Update() {
        if (transform.position.z < -10.0f || transform.position.z > 10.0f) {
            Destroy(gameObject);
        }
    }
}
