using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //-1 0 1
    private int lane;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Awake()
    {
        startPosition = transform.position;
        targetPosition = startPosition;
    }
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Move left
            lane = (lane == -1) ? -1 : lane - 1;
            targetPosition = startPosition + lane * Vector3.right * 0.3f;
        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Move right
            lane = (lane == 1) ? 1 : lane + 1;
            targetPosition = startPosition + lane * Vector3.right * 0.3f;
        } else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //Jump thing
        } else if (Input.GetKeyUp(KeyCode.PageDown))
        {
            //Slide thing
        }
        //Lerp
        transform.position = Vector3.Lerp(transform.position,targetPosition,0.25f);
	}

    
}
