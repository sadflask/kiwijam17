using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //-1 0 1
    private int lane;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    bool jumping, ducking;

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
            if (!(jumping || ducking)) StartCoroutine(Jump());
            //Jump thing
        } else if (Input.GetKeyUp(KeyCode.PageDown))
        {
            //Slide thing
            if (!(jumping || ducking)) StartCoroutine(Duck());
        }
        //Lerp
        transform.position = Vector3.Lerp(transform.position,targetPosition,0.25f);
	}
    IEnumerator Jump()
    {
        jumping = true;
        float start = Time.time;
        float elapsed = 0;
        while(elapsed < 0.5f)
        {
            targetPosition.y = 7.5f * elapsed * (0.5f - elapsed) + 0.15f;
            yield return new WaitForSeconds(0.01f);
            elapsed = Time.time - start;
        }
        jumping = false;
    }
    IEnumerator Duck()
    {
        ducking = true;
        float start = Time.time;
        float elapsed = 0;
        while (elapsed < 0.5f)
        {
            yield return new WaitForSeconds(0.01f);
            elapsed = Time.time - start;
        }
        ducking = false;
    }

}
