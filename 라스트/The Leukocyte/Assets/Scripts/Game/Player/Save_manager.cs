using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save_manager : MonoBehaviour {

    public Image save_ui;
    static string savepath = "THELEUKOCYTE.save";
    private Inventory inventory;
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            save_data();
    }

    void save_data()
    {
        //1
        Save save = CreateSaveGameObject();
        //2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savepath);
        bf.Serialize(file, save);
        file.Close();

        save_ui.gameObject.SetActive(true);
    }

    public void exit_ui()
    {
        save_ui.gameObject.SetActive(false);
    }

    private Save CreateSaveGameObject()
    { // 세이브 과정
        Save save = new Save();

        // 저장 장소 저장
        if (scene.name == "HOME")
            save.save_home = 0;
        else save.save_home = 1;
        
        // 캐릭터 정보 저장
        save.nickname = player_.player_info_nick;
        save.lavel = player_.player_info_level;
        save.hp = player_.player_info_hp;
        save.exp = player_.player_info_exp;
        save.money = player_.player_info_money;
        save.attack = player_.player_info_attack;

        // 맵 관련
        save.animation_off = map_.animation_off;
        save.first_slot_setting = inventory_.first_slot_setting;
        save.town_off = map_.town_off;

        // 무기 저장
        save.hasWeapon1 = inventory_.hasWeapon1;
        save.hasWeapon2 = inventory_.hasWeapon2;
        save.hasWeapon3 = inventory_.hasWeapon3;
        save.hasWeapon4 = inventory_.hasWeapon4;
        save.hasWeapon5 = inventory_.hasWeapon5;
        save.hasWeapon6 = inventory_.hasWeapon6;

        // 인벤토리 저장
        for (int i = 0; i < 9; i++)
        {
            save.weapon_items[i] = inventory_.weapon_items[i];
            save.potion_items[i] = inventory_.potion_items[i];
            save.etc_items[i] = inventory_.etc_items[i];

            save.weapon_name[i] = inventory_.weapon_name[i];
            save.potion_name[i] = inventory_.potion_name[i];
            save.etc_name[i] = inventory_.etc_name[i];

            save.weapon_items_number[i] = inventory_.weapon_items_number[i];
            save.potion_items_number[i] = inventory_.potion_items_number[i];
            save.etc_items_number[i] = inventory_.etc_items_number[i];
        }

        // 퀘스트 저장
        save.monsterDie = Quest.monsterDie;
        for (int j = 0; j < 10; j++)
        {
            save.isclear[j] = Quest.isclear[j];
            save.iscomplete[j] = Quest.iscomplete[j];
            save.viewing[j] = Quest.viewing[j];
            save.questplaying[j] = Quest.questplaying[j];
        }

        return save;
    }

   
}
