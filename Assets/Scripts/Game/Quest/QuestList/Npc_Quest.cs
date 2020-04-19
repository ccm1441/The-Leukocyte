using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest : MonoBehaviour {
    public GameObject clear;
    public GameObject nonclear;
    public GameObject Questing;

   
 	// Use this for initialization
	void Start () {
        clear.SetActive(false);
        nonclear.SetActive(false);
        Questing.SetActive(false);
        Quest.viewing[0] = false;
            
            }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[0] == false)
            {
                Debug.Log("Quest ing");
                Quest.queststart[0] = true;
            }
            else if (Quest.questplaying[0] == true && Quest.isclear[0] == true)
            {
                Debug.Log("clear Complete");
                player_.player_info_exp += 40;
                player_.player_info_money += 300;
                Quest.questplaying[0] = false;
                Quest.iscomplete[0] = true;
                Quest.viewing[0] = true;
                Quest.monsterDie = 0;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[0] == false && Quest.questplaying[0] == false)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[0] == true && Quest.questplaying[0] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[0] == false && Quest.questplaying[0] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[0] == false && Quest.isclear[0] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }

            
    }
    // Update is called once per frame
    void Update()
    {
        clearmark();

    }
}
