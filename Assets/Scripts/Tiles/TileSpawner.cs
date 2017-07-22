using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
    public static TileSpawner instance;

    public bool spawnObject = true;
    private Tile lastTile;

    [SerializeField]
    private Tile[] tiles;

    private float[] tileSpawnChances = { 1 };

    //Might not need
    private List<Tile> spawnedTiles = new List<Tile>();

    const float startSpeed = 0.05f;
    float speed;
    const float maxSpeed = 0.1f;

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
        speed = startSpeed;
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
                lastTile = SpawnTile(lastTile.transform.position - Vector3.back);
            }
            spawnedTiles.Add(lastTile);
            numberSpawnedTiles++;
        }
    }
    public void Collision()
    {
        StartCoroutine(SlowPlayer());
    }
    IEnumerator SlowPlayer()
    {
        float slowedSpeed = 0;
        float start = Time.time;
        float elapsed = 0;
        while(elapsed < 2)
        {
            if (elapsed < 1) slowedSpeed = 0.01f;
            else slowedSpeed = Mathf.Clamp( slowedSpeed + Time.deltaTime * 0.5f,0,speed);
            foreach(Tile t in spawnedTiles)
            {
                t.tMover.speed = slowedSpeed;
            }
            elapsed = Time.time - start;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private Tile SpawnTile(Vector3 spawnPosition)
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
        Tile t = (Instantiate(tiles[indexToSpawn], spawnPosition, Quaternion.Euler(90, 0, 0))).GetComponent<Tile>();
        t.tMover.speed = speed;
        return t;
    } 
}
