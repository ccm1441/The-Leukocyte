using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest2 : MonoBehaviour
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
        Quest.viewing[1] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[1] == false && Quest.iscomplete[0] == true && player_.player_info_level >= 2)
            {
                Debug.Log("Quest ing2");
                Quest.queststart[1] = true;
            }
            else if (Quest.questplaying[1] == true && Quest.isclear[1] == true)
            {
                Debug.Log("clear Complete2");
                player_.player_info_exp += 50;
                player_.player_info_money += 400;
                Quest.questplaying[1] = false;
                Quest.iscomplete[1] = true;
                Quest.viewing[1] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[1] == false && Quest.questplaying[1] == false && Quest.iscomplete[0] == true && player_.player_info_level >=2)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[1] == true && Quest.questplaying[1] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[1] == false && Quest.questplaying[1] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[1] == false && Quest.isclear[1] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if(Quest.iscomplete[0] == false || player_.player_info_level < 2)
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