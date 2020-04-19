
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_manager : MonoBehaviour
{

    private Inventory inventory;
    public Image fade;
    public Text load_t;
    static string savepath = "THELEUKOCYTE.save";
    public CreateNick createNick;
    public bool no_file = false;


    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    { //데이터 로드
        if (!fade.gameObject.activeSelf)
            fade.gameObject.SetActive(true);

        if (File.Exists(savepath))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savepath, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // 1번 - 저장 장소 배치
            if (save.save_home == 0) map_.load_map = 0;
            else map_.load_map = 1;

            // 2번 - 플레이어 정보 로드
            player_.player_info_nick = save.nickname;
            player_.player_info_level = save.lavel;
            player_.player_info_hp = save.hp;
            player_.player_info_exp = save.exp;
            player_.player_info_money = save.money;
            player_.player_info_attack = save.attack;

            Debug.Log(player_.player_info_nick);

            //무기가져옴
            inventory_.hasWeapon1 = save.hasWeapon1;
            inventory_.hasWeapon2 = save.hasWeapon2;
            inventory_.hasWeapon3 = save.hasWeapon3;
            inventory_.hasWeapon4 = save.hasWeapon4;
            inventory_.hasWeapon5 = save.hasWeapon5;
            inventory_.hasWeapon6 = save.hasWeapon6;

            // 3번 - 인벤토리 아이템 로드
            for (int i = 0; i < 9; i++)
            {
                inventory_.weapon_items[i] = save.weapon_items[i];
                inventory_.potion_items[i] = save.potion_items[i];
                inventory_.etc_items[i] = save.etc_items[i];

                inventory_.weapon_name[i] = save.weapon_name[i];
                inventory_.potion_name[i] = save.potion_name[i];
                inventory_.etc_name[i] = save.etc_name[i];

                inventory_.weapon_items_number[i] = save.weapon_items_number[i];
                inventory_.potion_items_number[i] = save.potion_items_number[i];
                inventory_.etc_items_number[i] = save.etc_items_number[i];

                for (int j = 0; j < inventory.weapon_item.Length; j++)
                {
                    if (inventory_.weapon_name[i] == inventory.weapon_item[j].name)
                    {
                        inventory_.weapon_item_object[i] = inventory.weapon_item[j];
                        break;
                    }
                }
                for (int j = 0; j < inventory.potion_item.Length; j++)
                {
                    if (inventory_.potion_name[i] == inventory.potion_item[j].name)
                    {
                        inventory_.potion_item_object[i] = inventory.potion_item[j];
                        break;
                    }
                }
                for (int j = 0; j < inventory.etc_item.Length; j++)
                {
                    if (inventory_.etc_name[i] == inventory.etc_item[j].name)
                    {
                        inventory_.etc_item_object[i] = inventory.etc_item[j];
                        break;
                    }
                }
            }

            //4번 퀘스트
            Quest.monsterDie = save.monsterDie;
            for (int j = 0; j < 10; j++)
            {
                Quest.isclear[j] = save.isclear[j];
                Quest.iscomplete[j] = save.iscomplete[j];
                Quest.viewing[j] = save.viewing[j];
                Quest.questplaying[j] = save.questplaying[j];
            }

            //5번 맵
            map_.animation_off = save.animation_off;
            inventory_.first_slot_setting = save.first_slot_setting;
            map_.town_off = save.town_off;
        }
        else
        {
            no_file = true;
           createNick.start_t.gameObject.SetActive(false);
            createNick.load_t.gameObject.SetActive(false);
            createNick.setting_t.gameObject.SetActive(false);
            createNick.exit_t.gameObject.SetActive(false);

            createNick.start_b.SetActive(false);
            createNick.load_b.SetActive(false);
            createNick.setting_b.SetActive(false);
            createNick.exit_b.SetActive(false);

            createNick.nick_b.SetActive(true);
            createNick.nick_box.gameObject.SetActive(true);
            createNick.nick_title.gameObject.SetActive(true);
            createNick.nick_t.gameObject.SetActive(true);
        }
    }


}
