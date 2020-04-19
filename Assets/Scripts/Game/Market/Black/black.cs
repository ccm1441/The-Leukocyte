using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black : MonoBehaviour
{

    public GameObject black_ui;
    public GameObject black_exit;
    public Collider2D black_coli;


    // Use this for initialization
    void Start()
    {
        black_ui.gameObject.SetActive(false);
        black_exit.gameObject.SetActive(false);

    }

    private void OnTriggerStay2D(Collider2D hit)
    {
        if (Input.GetButtonDown("subkey") && !market_.black_use)
        {
            if (hit.CompareTag("Player"))
            {
                if (Quest.iscomplete[7] == true)
                {
                    black_ui.gameObject.SetActive(true);
                    black_exit.gameObject.SetActive(true);
                    market_.black_use = true;
                    black_coli.enabled = false;
                }
            }
        }
    }

    public void exit()
    {
        black_ui.gameObject.SetActive(false);
        black_exit.gameObject.SetActive(false);
    }
}
