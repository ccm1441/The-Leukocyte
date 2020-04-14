using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateNick : MonoBehaviour {

    public Text start_t;
    public Text load_t;
    public Text setting_t;
    public Text exit_t;

    public GameObject start_b;
    public GameObject load_b;
    public GameObject setting_b;
    public GameObject exit_b;

    public GameObject nick_b;
    public Text nick_t;
    public Text nick_title;
    public InputField nick_box;

  //  public Text nick_ui;
    public Text nick;


    public void start_nick()
    {
        start_t.gameObject.SetActive(false);
        load_t.gameObject.SetActive(false);
        setting_t.gameObject.SetActive(false);
        exit_t.gameObject.SetActive(false);
        
        start_b.SetActive(false);
        load_b.SetActive(false);
        setting_b.SetActive(false);
        exit_b.SetActive(false);

        nick_b.SetActive(true);
        nick_box.gameObject.SetActive(true);
        nick_title.gameObject.SetActive(true);
        nick_t.gameObject.SetActive(true);


    }

    private void FixedUpdate()
    {
        player_.player_info_nick = nick.text;
    }

}
