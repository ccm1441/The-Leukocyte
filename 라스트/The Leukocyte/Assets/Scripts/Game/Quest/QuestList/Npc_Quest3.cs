using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest3 : MonoBehaviour
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
        Quest.viewing[2] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[2] == false && Quest.iscomplete[1] == true && player_.player_info_level >= 3)
            {
                Debug.Log("Quest ing3");
                Quest.queststart[2] = true;
            }
            else if (Quest.questplaying[2] == true && Quest.isclear[2] == true)
            {
                Debug.Log("clear Complete3");
                player_.player_info_exp += 50;
                player_.player_info_money += 400;
                Quest.questplaying[2] = false;
                Quest.iscomplete[2] = true;
                Quest.viewing[2] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[2] == false && Quest.questplaying[2] == false && Quest.iscomplete[1] == true && player_.player_info_level >= 3)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[2] == true && Quest.questplaying[2] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[2] == false && Quest.questplaying[2] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[2] == false && Quest.isclear[2] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[1] == false || player_.player_info_level < 3)
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
