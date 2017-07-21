using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if(gameObject.transform.localPosition.z < -6)
        {
            TileSpawner.instance.numberSpawnedTiles--;
            Destroy(gameObject);
        }
	}
}
