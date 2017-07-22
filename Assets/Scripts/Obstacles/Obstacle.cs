using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	private const float LANE_WIDTH = 0.3F;

	public enum Position
	{
		left,
		center,
		right
	}

	public Position position;

	// Use this for initialization
	void Start () {
		switch (position) {
			case Position.left:
				this.transform.localPosition += Vector3.left * LANE_WIDTH;
				break;
			case Position.	right:
				this.transform.localPosition += Vector3.right * LANE_WIDTH;
				break;
			default:
			 break;
		}
	}

}
