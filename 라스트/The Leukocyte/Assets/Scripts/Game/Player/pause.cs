using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
   
    public static bool isPausing=false;
    private bool opened=false;
    public GameObject pauseText;
    public GameObject[] monsters;
    public GameObject player;
    public Scene scene;
    public GameObject subBoss;
    public GameObject Boss;
    public GameObject pump_Left;
    public GameObject pump_Right;

    // Use this for initialization
    void Start()
    {
       scene = SceneManager.GetActiveScene();
        pauseText.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")&&!opened)
        {
            pauseText.SetActive(true);
            if(scene.name != "HOME" || scene.name != "Capillary_Home")
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    monsters[i].GetComponent<MonsterMove>().enabled = false;
                }
            }            
            if(scene.name=="Brain")
            {
                subBoss.GetComponent<BossMovement>().enabled = false;
                subBoss.GetComponent<BossFire>().enabled = false;
            }
            else if (scene.name == "Heart4")
            {
                Boss.GetComponent<EbolaBoss>().enabled = false;
                pump_Left.GetComponent<Pump>().enabled = false;
                pump_Right.GetComponent<Pump>().enabled = false;
            }
            else if (scene.name == "Liver")
            {
                subBoss.GetComponent<MonsterMove>().enabled = false;
                subBoss.GetComponent<BossMovement>().enabled = false;
            }
            else if (scene.name == "Lungs")
            {
                subBoss.GetComponent<BossMovement>().enabled = false;
                subBoss.GetComponent<MersFireInducement>().enabled = false;
            }
            else if (scene.name == "Stomach")
            {
                subBoss.GetComponent<MonsterMove>().enabled = false;
                subBoss.GetComponent<superBacteriaAttack>().enabled = false;
            }
            isPausing = true;
            opened = true;
        }
        else if (Input.GetButtonDown("Pause") &&opened)
        {
            back();
        }
    }

    public void go_main()
    {
        SceneManager.LoadScene("Opening");

    }
    public void back()
    {
        pauseText.SetActive(false);
        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].GetComponent<MonsterMove>().enabled = true;

        }
        if (scene.name == "Brain")
        {
            subBoss.GetComponent<BossMovement>().enabled = true;
            subBoss.GetComponent<BossFire>().enabled = true;
        }
        else if (scene.name == "Heart4")
        {
            Boss.GetComponent<EbolaBoss>().enabled = true;
            pump_Left.GetComponent<Pump>().enabled = true;
            pump_Right.GetComponent<Pump>().enabled = true;
        }
        else if (scene.name == "Liver")
        {
            subBoss.GetComponent<MonsterMove>().enabled = true;
            subBoss.GetComponent<BossMovement>().enabled = true;
        }
        else if (scene.name == "Lungs")
        {
            subBoss.GetComponent<BossMovement>().enabled = true;
            subBoss.GetComponent<MersFireInducement>().enabled = true;
        }
        else if (scene.name == "Stomach")
        {
            subBoss.GetComponent<MonsterMove>().enabled = true;
            subBoss.GetComponent<superBacteriaAttack>().enabled = true;
        }
        isPausing = false;
        opened = false;
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
