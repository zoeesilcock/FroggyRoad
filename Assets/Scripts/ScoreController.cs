using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

    public GameObject _player;
    public float _startPosition;

    void Start() {
    }

    void Update() {
        gameObject.GetComponent<Text>().text = "Points: " + Mathf.Floor(_player.transform.position.x - _startPosition);
    }
}
