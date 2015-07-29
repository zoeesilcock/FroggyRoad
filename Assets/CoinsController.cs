using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsController : MonoBehaviour {

    void Update() {
        transform.GetComponent<Text>().text = "Coins: " + ApplicationModel._coinCount;
    }
}
