using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest6 : MonoBehaviour
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
        Quest.viewing[5] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[5] == false && Quest.iscomplete[4] == true && player_.player_info_level >= 6)
            {
                Debug.Log("Quest ing6");
                Quest.queststart[5] = true;
            }
            else if (Quest.questplaying[5] == true && Quest.isclear[5] == true)
            {
                Debug.Log("clear Complete6");
                player_.player_info_exp += 60;
                player_.player_info_money += 400;
                Quest.questplaying[5] = false;
                Quest.iscomplete[5] = true;
                Quest.viewing[5] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[5] == false && Quest.questplaying[5] == false && Quest.iscomplete[4] == true && player_.player_info_level >= 6)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[5] == true && Quest.questplaying[5] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[5] == false && Quest.questplaying[5] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[5] == false && Quest.isclear[5] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[4] == false || player_.player_info_level < 6)
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
