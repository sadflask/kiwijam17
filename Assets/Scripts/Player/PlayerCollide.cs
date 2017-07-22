﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

    public Player p;
	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("obstacle"))
        {
            //Slow the player?
            Debug.Log("Hit");
        }
    }
}