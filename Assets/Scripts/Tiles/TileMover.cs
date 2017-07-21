﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        speed = 0.05f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.position += Vector3.back * speed;
	}
}
