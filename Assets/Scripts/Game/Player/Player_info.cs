using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_info : MonoBehaviour {

    // #####################################
    // #                                   #
    // #           캐릭터 정보             #
    // #                                   #
    // #####################################

    private Text money;
    private GameObject inventory;
    private GameObject info_ui;
    private Image hp_bar;
    private Image exp_bar;
    private Text level;
    private Text nickname;
    public Image death;
    public Text rip_nick;
    public ParticleSystem level_up;
    public ParticleSystem class_change;

    public AudioClip levelupSound;

    // Use this for initialization
    void Start() {

        if (player_.player_left)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        inventory = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        info_ui = GameObject.Find("Canvas").transform.Find("info").gameObject;
        hp_bar = info_ui.transform.Find("hp_bar").GetComponent<Image>();
        exp_bar = info_ui.transform.Find("exp_bar").GetComponent<Image>();
        level = info_ui.transform.Find("info_text_canvas").transform.Find("lv").GetComponent<Text>();
        money = inventory.transform.Find("Money").GetComponent<Text>();
        nickname = info_ui.transform.Find("info_text_canvas").transform.Find("nick").GetComponent<Text>();

        nickname.text = player_.player_info_nick;
        money.text = player_.player_info_money.ToString();
        level.text = "Lv." + player_.player_info_level.ToString();
        level_up.Pause();

        sound_.level_sound = gameObject.GetComponent<AudioSource>();
        sound_.level_sound.clip = levelupSound;

        class_change.Pause();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(player_.player_info_nick);
        nickname.text = player_.player_info_nick;
        money.text = player_.player_info_money.ToString();
        money.text = player_.player_info_money.ToString();
        exp_bar.fillAmount = player_.player_info_exp * 0.01f;
        hp_bar.fillAmount = player_.player_info_hp * 0.01f;
        level.text = "Lv." + player_.player_info_level.ToString();

        if (exp_bar.fillAmount >= 1f && player_.player_info_level != 12)
        {
            sound_.level_sound = gameObject.GetComponent<AudioSource>();
            sound_.level_sound.clip = levelupSound;
            sound_.level_sound.Play();
            level_up.Play();
            player_.player_info_level++;
            player_.player_info_exp = 0;
            player_.player_info_hp = 100;

            if (player_.player_info_level == 4 || player_.player_info_level == 7 || player_.player_info_level == 10)
                class_change.Play();
        }

        if (player_.player_info_hp <= 0)
        {
            death.gameObject.SetActive(true);
            rip_nick.text = player_.player_info_nick;
            StartCoroutine("death_time");
            transform.position = new Vector3(-10, 10);        
        }
        else death.gameObject.SetActive(false);
    }

    IEnumerator death_time()
    {
        yield return new WaitForSeconds(5);

        player_.player_info_hp = 100;
        if(map_.town_off) SceneManager.LoadScene("Town");
        else SceneManager.LoadScene("Game_square");
    }
        
}
