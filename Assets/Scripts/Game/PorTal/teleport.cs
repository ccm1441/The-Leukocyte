using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour {

    public GameObject tele_ui;

    private void Start()
    {
        tele_ui.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Quest.iscomplete[3] == true)
            {
                tele_ui.SetActive(true);
            }
        }
    }

    public void Go_capillary()
    {
        SceneManager.LoadScene("Capillary");
    }

    public void Go_gallbladder()
    {
        SceneManager.LoadScene("Gallbladder");
    }

    public void Go_town()
    {
        SceneManager.LoadScene("Town");
    }

    public void exit_Te()
    {
        tele_ui.SetActive(false);
    }
}
