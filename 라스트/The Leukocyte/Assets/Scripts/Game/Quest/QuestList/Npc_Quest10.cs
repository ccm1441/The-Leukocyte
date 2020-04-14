using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest10 : MonoBehaviour
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
        Quest.viewing[9] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[9] == false &&Quest.iscomplete[8] == true && player_.player_info_level >= 10)
            {
                Debug.Log("Quest ing10");
                Quest.queststart[9] = true;
            }
            else if (Quest.questplaying[9] == true && Quest.isclear[9] == true)
            {
                Debug.Log("clear Complete10");
                player_.player_info_exp += 60;
                player_.player_info_money += 400;
                Quest.questplaying[9] = false;
                Quest.iscomplete[9] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[9] == false && Quest.questplaying[9] == false && Quest.iscomplete[8] == true && player_.player_info_level >= 10)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[9] == true && Quest.questplaying[9] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[9] == false && Quest.questplaying[9] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[9] == false && Quest.isclear[9] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[8] == false || player_.player_info_level < 10)
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