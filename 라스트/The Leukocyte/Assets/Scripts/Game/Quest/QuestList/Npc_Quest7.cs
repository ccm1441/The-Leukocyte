using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest7 : MonoBehaviour
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
        Quest.viewing[6] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[6] == false && Quest.iscomplete[5] == true && player_.player_info_level >= 7)
            {
                Debug.Log("Quest ing6");
                Quest.queststart[6] = true;
            }
            else if (Quest.questplaying[6] == true && Quest.isclear[6] == true)
            {
                Debug.Log("clear Complete6");
                player_.player_info_exp += 50;
                player_.player_info_money += 400;
                Quest.questplaying[6] = false;
                Quest.iscomplete[6] = true;
                Quest.viewing[6] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[6] == false && Quest.questplaying[6] == false && Quest.iscomplete[5] == true && player_.player_info_level >= 7)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[6] == true && Quest.questplaying[6] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[6] == false && Quest.questplaying[6] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[6] == false && Quest.isclear[6] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[5] == false || player_.player_info_level < 7)
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