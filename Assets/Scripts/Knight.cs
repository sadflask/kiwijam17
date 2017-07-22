using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour {

	public float speed = 0;
	private Rigidbody rb;

	public void Awake()
	{
		// rb = GetComponent<Rigidbody>();
		// speed = 0.5f;
	}

	public void FixedUpdate()
	{
		// var realSpeed = this.speed - road.speed;
		// rb.position += Vector3.forward * realSpeed;
	}
}
