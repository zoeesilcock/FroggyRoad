using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelController : MonoBehaviour {

    public GameObject _player;
    public GameObject _grassPrefab;
    public GameObject _roadPrefab;
    public float _spaceForwards;
    public float _spaceBackwards;
    public int _maxGrassCount;
    public int _maxRoadCount;

    private Transform firstLevelSection;
    private Transform lastLevelSection;
    private int grassCount;
    private int roadCount;

    void Start() {
    }

    void Update() {
        IdentifyFirstAndLast();

        if (_player.transform.position.x > firstLevelSection.position.x + _spaceBackwards) {
            Destroy(firstLevelSection.gameObject);
        }

        if (_player.transform.position.x + _spaceForwards > lastLevelSection.position.x) {
            GenerateNewSection();
        }
    }

    void IdentifyFirstAndLast() {
        firstLevelSection = gameObject.GetComponentsInChildren<Transform>().Skip(1).OrderBy(t => t.position.x).First();
        lastLevelSection = gameObject.GetComponentsInChildren<Transform>().Skip(1).OrderBy(t => t.position.x).Last();
    }

    void GenerateNewSection() {
        GameObject prefab = _grassPrefab;

        if (Random.value > 0.75) {
            prefab = _roadPrefab;
            roadCount += 1;
        } else {
            grassCount += 1;
        }

        if (grassCount >= _maxGrassCount) {
            prefab = _roadPrefab;
            grassCount = 0;
        }

        if (roadCount >= _maxRoadCount) {
            prefab = _grassPrefab;
            roadCount = 0;
        }

        GameObject section = Instantiate(prefab, new Vector3(lastLevelSection.position.x + 2, prefab.transform.position.y, lastLevelSection.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
        section.transform.parent = transform;
        IdentifyFirstAndLast();
    }
}
