using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest5 : MonoBehaviour
{
    public GameObject clear;
    public GameObject nonclear;
    public GameObject Questing;

    // Use this for initialization
    void Start()
    {
        clear.SetActive(false);
        nonclear.SetActive(false);
        Questing.SetActive(false);
        Quest.viewing[4] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[4] == false && Quest.iscomplete[3] == true && player_.player_info_level >= 5)
            {
                Debug.Log("Quest ing4");
                Quest.queststart[4] = true;
            }
            else if (Quest.questplaying[4] == true && Quest.isclear[4] == true)
            {
                Debug.Log("clear Complete4");
                player_.player_info_exp += 60;
                player_.player_info_money += 400;
                Quest.questplaying[4] = false;
                Quest.iscomplete[4] = true;
                Quest.viewing[4] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[4] == false && Quest.questplaying[4] == false && Quest.iscomplete[3] == true && player_.player_info_level >= 5)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[4] == true && Quest.questplaying[4] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[4] == false && Quest.questplaying[4] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[4] == false && Quest.isclear[4] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if(Quest.iscomplete[3] == false || player_.player_info_level < 5)
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
