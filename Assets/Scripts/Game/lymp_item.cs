using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lymp_item : MonoBehaviour {

    public PickUp pickup;                              // pickup 스크립트 사용    
                                                   
    void Start () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Quest.questplaying[8] == true)
            {
                pickup.check_etc("Lymph_item",true);
                Quest.lymp_item = true;
                Quest.isclear[8] = true;
            }
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
