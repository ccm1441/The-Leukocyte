using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {
 
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {


    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("Foot"))
        {
            PlayerMove.speed = 1;
        }
    }
    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.CompareTag("Foot"))
        {
            PlayerMove.speed = 1;
        }
    }
      void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Foot"))
        {
            PlayerMove.speed = 5;
        }
    }
}
