using UnityEngine;
using System.Collections;

public class GrassController : MonoBehaviour {

    public GameObject _treePrefab1;
    public GameObject _treePrefab2;

    void Start() {
        SpawnTreeBarrier(-0.5f, -9.5f);
        SpawnTreeBarrier(-0.5f, 5.5f);
    }

    void Update() {
        /* Renderer grassRenderer = gameObject.GetComponent<Renderer>(); */
        /* grassRenderer.material.color = new Color(Random.value, Random.value, Random.value); */
    }

    void SpawnTreeBarrier(float startX, float startZ) {
        GameObject prefab = _treePrefab2;

        for (int column = 0; column < 5; column++) {
            for (int row = 0; row < 2; row++) {
                if (Random.value < 0.5f) {
                    prefab = _treePrefab1;
                } else {
                    prefab = _treePrefab2;
                }

                Vector3 spawnPosition = new Vector3(transform.position.x + startX + row, transform.position.y + 0.2f, transform.position.z + startZ + column);
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
