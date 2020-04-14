using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest9 : MonoBehaviour
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
        Quest.viewing[8] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[8] == false &&Quest.iscomplete[7] == true && player_.player_info_level >= 9)
            {
                Debug.Log("Quest ing9");
                Quest.queststart[8] = true;
            }
            else if (Quest.questplaying[8] == true && Quest.isclear[8] == true)
            {
                Debug.Log("clear Complete9");
                player_.player_info_exp += 60;
                player_.player_info_money += 400;
                Quest.questplaying[8] = false;
                Quest.iscomplete[8] = true;
                Quest.viewing[8] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[8] == false && Quest.questplaying[8] == false && Quest.iscomplete[7] == true && player_.player_info_level >= 9)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[8] == true && Quest.questplaying[8] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[8] == false && Quest.questplaying[8] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[8] == false && Quest.isclear[8] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[7] == false || player_.player_info_level < 9)
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