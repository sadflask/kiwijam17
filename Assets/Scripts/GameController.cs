using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour {

    public static GameController instance;

    public const float length = 100;
    public float progress;
    public float lead;

    const float startSpeed = 2f;
    //increasing over time speed of road
    public float speed;
    //Current speed of road 
    public float adjustedSpeed;
    const float maxSpeed = 10f;

    const float knightStartSpeed = 1.9f;
    public float knightSpeed;
    const float knightMaxSpeed = 9.9f;

    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        progress = 0;
        lead = 10;
        speed = startSpeed;
        adjustedSpeed = speed;
        knightSpeed = knightStartSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        progress += adjustedSpeed * Time.deltaTime;
        Debug.Log(string.Format("Current progress: {0}", progress));
        lead += (adjustedSpeed - knightSpeed) * Time.deltaTime;
        Debug.Log(string.Format("Current lead: {0}", lead));
    }
}
