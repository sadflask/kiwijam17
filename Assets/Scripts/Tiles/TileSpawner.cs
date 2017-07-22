using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
    public static TileSpawner instance;

    public bool spawnObject = true;
    private GameObject lastTile;

    [SerializeField]
    private GameObject[] tiles;

    private float[] tileSpawnChances = { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.5f };

    //Might not need
    private List<GameObject> spawnedTiles;

    [SerializeField]
    private Transform spawnPosition;

    public int numberSpawnedTiles;
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        } else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        numberSpawnedTiles = 0;
	}
	
	void LateUpdate() { 
            if (spawnObject)
            {
                spawnObject = false;
                if (lastTile == null)
                {
                    lastTile = SpawnTile(spawnPosition.position);
                }
                else
                {
                    lastTile = SpawnTile(lastTile.transform.position -Vector3.back);
                }
                spawnedTiles.Add(lastTile);
                numberSpawnedTiles++;
            }
    }
    private GameObject SpawnTile(Vector3 spawnPosition)
    {
        int indexToSpawn = 0;
        float rng = Random.Range(0, 1.0f);
        float cumulativeChance = 0;
        for(int i=0; i<tiles.Length; i++)
        {
            if(rng < tileSpawnChances[i]+cumulativeChance)
            {
                indexToSpawn = i;
                break;
            }
            cumulativeChance += tileSpawnChances[i];
        }
        GameObject g = Instantiate(tiles[indexToSpawn], spawnPosition, Quaternion.Euler(90,0,0));
        return g;
    } 
}
