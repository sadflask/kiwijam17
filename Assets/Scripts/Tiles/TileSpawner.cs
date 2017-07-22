using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {
    public static TileSpawner instance;

    public GameController gc;
    public bool spawnObject = true;
    private Tile lastTile;

    [SerializeField]
    private Tile[] tiles;

    private float[] tileSpawnChances = { 1 };

    //Might not need
    private List<Tile> spawnedTiles = new List<Tile>();

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
        gc = GameController.instance;
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
        float start = Time.time;
        float elapsed = 0;
        while(elapsed < 2)
        {
            if (elapsed < 1)  gc.adjustedSpeed= 0.01f;
            else gc.adjustedSpeed = Mathf.Clamp( gc.adjustedSpeed + Time.deltaTime * 1f,0,gc.speed);
            foreach(Tile t in spawnedTiles)
            {
                t.tMover.speed = gc.adjustedSpeed;
            }
            elapsed = Time.time - start;
            yield return new WaitForSeconds(0.01f);
        }
        gc.adjustedSpeed = gc.speed;
        foreach (Tile t in spawnedTiles)
        {
            t.tMover.speed = gc.adjustedSpeed;
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
        t.tMover.speed = gc.speed;
        return t;
    } 
}
