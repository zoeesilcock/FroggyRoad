using UnityEngine;
using System.Collections;
using System.Linq;

public class LevelController : MonoBehaviour {

    public GameObject _player;
    public GameObject _grassPrefab;
    public float _spaceForwards;
    public float _spaceBackwards;

    private Transform firstLevelSection;
    private Transform lastLevelSection;

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
        GameObject section = Instantiate(_grassPrefab, new Vector3(lastLevelSection.position.x + 2, lastLevelSection.position.y, lastLevelSection.position.z), Quaternion.Euler(270, 0, 0)) as GameObject;
        section.transform.parent = transform;
        IdentifyFirstAndLast();
    }
}
