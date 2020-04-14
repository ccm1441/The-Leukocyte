using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Quest8 : MonoBehaviour
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
        Quest.viewing[7] = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Quest.isclear[7] == false && Quest.iscomplete[6] == true && player_.player_info_level >= 8)
            {
                Debug.Log("Quest ing8");
                Quest.queststart[7] = true;
            }
            else if (Quest.questplaying[7] == true && Quest.isclear[7] == true)
            {
                Debug.Log("clear Complete8");
                player_.player_info_exp += 60;
                player_.player_info_money += 400;
                Quest.questplaying[7] = false;
                Quest.iscomplete[7] = true;
                Quest.viewing[7] = true;
            }
        }
    }

    public void clearmark()
    {
        if (Quest.isclear[7] == false && Quest.questplaying[7] == false&& Quest.iscomplete[6] == true && player_.player_info_level >= 8)
        {
            clear.SetActive(false);
            nonclear.SetActive(true);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[7] == true && Quest.questplaying[7] == true)
        {
            clear.SetActive(true);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.isclear[7] == false && Quest.questplaying[7] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(true);
        }
        else if (Quest.questplaying[7] == false && Quest.isclear[7] == true)
        {
            clear.SetActive(false);
            nonclear.SetActive(false);
            Questing.SetActive(false);
        }
        else if (Quest.iscomplete[6] == false || player_.player_info_level < 8)
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