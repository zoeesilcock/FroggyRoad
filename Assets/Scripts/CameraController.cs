using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject _player;
    public float _offsetX;
    public float _offsetZ;
    public float _smoothSpeed;

    void Update() {
        Vector3 target = new Vector3(_player.transform.position.x + _offsetX, transform.position.y, _player.transform.position.z + _offsetZ);
        transform.position = Vector3.Lerp(transform.position, target, _smoothSpeed * Time.deltaTime);
    }
}
