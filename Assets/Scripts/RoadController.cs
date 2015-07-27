using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {

    public GameObject _carPrefab;

    private float lastSpawnTimeLeft;
    private float spawnDelayLeft;
    private float lastSpawnTimeRight;
    private float spawnDelayRight;

    void Start() {
        SpawnCar(false);
        SpawnCar(true);
    }

    void Update() {
        if (lastSpawnTimeLeft + spawnDelayLeft < Time.time) {
            SpawnCar(false);
        }

        if (lastSpawnTimeRight + spawnDelayRight < Time.time) {
            SpawnCar(true);
        }
    }

    void SpawnCar(bool rightCar) {
        float offsetX = -0.5f;
        float offsetZ = 10.0f;
        Quaternion rotation = Quaternion.identity;
        float speed = 1.0f;

        if (!rightCar) {
            offsetX = 0.5f;
            offsetZ = -10.0f;
            rotation = Quaternion.Euler(0, 180, 0);
            speed = -1.0f;

            lastSpawnTimeLeft = Time.time;
            spawnDelayLeft = GetRandomDelay();
        } else {
            lastSpawnTimeRight = Time.time;
            spawnDelayRight = GetRandomDelay();
        }

        Vector3 spawnPosition = new Vector3(transform.position.x - offsetX, transform.position.y, transform.position.z - offsetZ);
        GameObject car = Instantiate(_carPrefab, spawnPosition, rotation) as GameObject;
        Renderer childRender = car.GetComponentInChildren<Renderer>() as Renderer;
        childRender.material.color = new Color(Random.value, Random.value, Random.value);

        car.GetComponent<CarController>()._speed = speed;
    }

    float GetRandomDelay() {
        float randomValue = Random.value;

        if (randomValue < 0.4f) {
            return 5.0f + Random.value;
        } else if (randomValue < 0.5f) {
            return 2.5f + Random.value;
        } else {
            return 7.5f + Random.value;
        }
    }
}
