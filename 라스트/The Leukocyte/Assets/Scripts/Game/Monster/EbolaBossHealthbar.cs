using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EbolaBossHealthbar : MonoBehaviour {

    public static bool Phase1=true;
    public static bool Phase2;
    public static bool Phase3;
    public static bool Phase4;
    public Image healthBar1;
    public Image healthBar2;
    public Image healthBar3;
    public Image healthBar4;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;

    public static float bossHealth1=1f;
    public static float bossHealth2 = 1f;
    public static float bossHealth3 = 1f;
    public static float bossHealth4 = 1f;

    // Use this for initialization
    void Start () {
        healthBar1 = GetComponent<Image>();
        healthBar2 = GetComponent<Image>();
        healthBar3 = GetComponent<Image>();
        healthBar4 = GetComponent<Image>();
     
    }
	
	// Update is called once per frame
	void Update () {
        healthBar1.fillAmount = (float)bossHealth1;
        if (health2.gameObject.activeInHierarchy)
        {
            Phase1 = false;
            Phase2 = true;
            healthBar2.fillAmount = (float)bossHealth2;
        }
        if (health3.gameObject.activeInHierarchy)
        {
            Phase2 = false;
            Phase3 = true;
            healthBar3.fillAmount = (float)bossHealth3;
        }
        if (health4.gameObject.activeInHierarchy)
        {
            Phase3 = false;
            Phase4 = true;
            healthBar4.fillAmount = (float)bossHealth4;
        }

            if (bossHealth1<=0.0f)
        {
            health2.gameObject.SetActive(true);
            health1.gameObject.SetActive(false);
        }
        if (bossHealth2 <= 0.0f)
        {
            health3.gameObject.SetActive(true);
            health2.gameObject.SetActive(false);
        }
        if (bossHealth3 <= 0.0f)
        {
            health4.gameObject.SetActive(true);
            health3.gameObject.SetActive(false);
        }
        if (bossHealth4 <= 0.0f)
        {
            health4.gameObject.SetActive(false);
            Phase4 = false;
            if(Quest.questplaying[9] == true)
            {
                health4.gameObject.SetActive(false);
                Phase4 = false;
                Quest.iscomplete[9] = true;
                SceneManager.LoadScene("Ending1");
            }
        }



    }
}
