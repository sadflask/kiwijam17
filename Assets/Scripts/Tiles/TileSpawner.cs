﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
    public static TileSpawner instance;

    public bool spawnObject = true;
    private GameObject lastTile;

    [SerializeField]
    private GameObject[] tiles;

    //Might not need
    private GameObject[] spawnedTiles;

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
                numberSpawnedTiles++;
            }
    }
    private GameObject SpawnTile(Vector3 spawnPosition)
    {
        int indexToSpawn = Random.Range(0, tiles.Length);
        GameObject g = Instantiate(tiles[indexToSpawn], spawnPosition, Quaternion.Euler(90,0,0));
        return g;
    } 
}
