using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

	void OnTriggerEnter()
    {
        TileSpawner.instance.spawnObject = true;
    }
}
