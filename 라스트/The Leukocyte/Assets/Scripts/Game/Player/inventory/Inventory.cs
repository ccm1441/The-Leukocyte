using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
                                                      // ##### 인벤토리 아이템 관련 #####
    
    public GameObject[] weapon_item;                  // 인벤에 표시할 무기 오브젝트
    public GameObject[] potion_item;                  // 인벤이 표시할 포션 오브젝트
    public GameObject[] etc_item;                     // 인벤이 표시할 기타 오브젝트

                                                      // ##### 인벤토리 UI 관련 #####
    static bool inventory_on = false;                 // 인벤 온오프 체크
    [HideInInspector]
    public GameObject inventory;                      // 인벤 게임오브젝트

    [HideInInspector]                                 // ##### 무기 인벤 관련 #####
    public GameObject inventory_weapon_ui;            // 무기 인벤창 UI
    private GameObject weapon_off;                    // 무기 인벤창 비활성시 버튼
    private GameObject weapon_on;                     // 무기 인벤창 활성시 버튼
    private GameObject weapon_number;
    static bool inventory_weapon_on = false;          // 무기 인벤창 온오프 체크
    
    [HideInInspector]                                 // ##### 물약 인벤 관련 ##### 
    public GameObject inventory_potion_ui;            // 물약 인벤창 UI
    private GameObject potion_off;                    // 물약 인벤창 비활성시 버튼
    private GameObject potion_on;                     // 물약 인벤창 활성시 버튼
    private GameObject potion_number;
    static bool inventory_potion_on = false;          // 물약 인벤창 온오프 체크

    [HideInInspector]                                 // ##### 기타 인벤 관련 #####      
    public GameObject inventory_etc_ui;               // 기타 인벤창 UI
    private GameObject etc_off;                       // 기타 인벤창 비활성시 버튼
    private GameObject etc_on;                        // 기타 인벤창 활성시 버튼
    private GameObject etc_number;
    static bool inventory_etc_on = false;             // 기타 인벤창 온오프 체크
    Scene scene;

    private void Start()
    {
        // 각 오브젝트 가져옴
        inventory = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;

        inventory_weapon_ui = GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("inventory_weapon_slot").gameObject;
        weapon_off = inventory.transform.Find("inven_weapon").transform.Find("inven_weapon_button").gameObject;
        weapon_on = inventory.transform.Find("inven_weapon").transform.Find("inven_weapon_button_on").gameObject;
        weapon_number = inventory.transform.Find("number").transform.Find("weapon").gameObject;

        inventory_potion_ui = GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("inventory_potion_slot").gameObject;
        potion_off = inventory.transform.Find("inven_potion").transform.Find("inven_potion_button").gameObject;
        potion_on = inventory.transform.Find("inven_potion").transform.Find("inven_potion_button_on").gameObject;
        potion_number = inventory.transform.Find("number").transform.Find("potion").gameObject;

        inventory_etc_ui = GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("inventory_etc_slot").gameObject;
        etc_off = inventory.transform.Find("inven_etc").transform.Find("inven_etc_button").gameObject;
        etc_on = inventory.transform.Find("inven_etc").transform.Find("inven_etc_button_on").gameObject;
        etc_number = inventory.transform.Find("number").transform.Find("etc").gameObject;


        // ##### 스타트시 옵션 설정 #####

        inventory_weapon_ui.gameObject.SetActive(true);// 무기 인벤창 활성화
        weapon_on.gameObject.SetActive(true);          // 무기 인벤창 활성버튼 활성화
        weapon_off.gameObject.SetActive(false);        // 무기 인벤창 비활성버튼 비활성화

       inventory_potion_ui.gameObject.SetActive(false); // 포션 인벤토리 끄기
        potion_off.gameObject.SetActive(true);
        potion_on.gameObject.SetActive(false);

        inventory_etc_ui.gameObject.SetActive(true); // 포션 인벤토리 끄기
        etc_off.gameObject.SetActive(true);
        etc_on.gameObject.SetActive(false);

        inventory.gameObject.SetActive(false);         // 인벤토리 끄기

        scene = SceneManager.GetActiveScene();
    }


    private void FixedUpdate()
    {

        if (!inventory_.get_inventory_pos)                    // ##### 인벤토리 위치 저장 #####
        {
            inventory_.inventory_x = inventory.transform.position.x;
            inventory_.inventory_y = inventory.transform.position.y;
            inventory_.get_inventory_pos = true;
        }

        if (Input.GetButtonDown("inventory") && scene.name !="Opening")           // ##### 인벤토리 열고 닫기 #####
        {
            if (inventory_on)
            {
                inventory.gameObject.SetActive(false);
                inventory_on = !inventory_on;
            }
            else
            {
                inventory.gameObject.SetActive(true);
                inventory.transform.position = new Vector3(inventory_.inventory_x, inventory_.inventory_y);
                inventory_on = !inventory_on;
                inventory_etc_on = false;
                inventory_potion_on = false;
                inventory_weapon_on = true;
            }           
        }
        if (inventory_weapon_on)                         // ##### 무기 인벤창 활성시 #####
        {
            inventory_weapon_ui.SetActive(true);
            inventory_potion_ui.SetActive(false);
            inventory_etc_ui.SetActive(false);

            weapon_on.gameObject.SetActive(true);
            weapon_off.gameObject.SetActive(false);
            weapon_number.gameObject.SetActive(true);

            potion_on.gameObject.SetActive(false);
            potion_off.gameObject.SetActive(true);
            potion_number.gameObject.SetActive(false);

            etc_on.gameObject.SetActive(false);
            etc_off.gameObject.SetActive(true);
            etc_number.gameObject.SetActive(false);
        }
        else
        {
            inventory_weapon_ui.SetActive(false);
            weapon_on.gameObject.SetActive(false);
            weapon_off.gameObject.SetActive(true);
        }

        if (inventory_potion_on)                          // ##### 물약 인벤창 활성시 #####
        {
            inventory_potion_ui.SetActive(true);
            inventory_weapon_ui.SetActive(false);
            inventory_etc_ui.SetActive(false);

            weapon_on.gameObject.SetActive(false);
            weapon_off.gameObject.SetActive(true);
            weapon_number.gameObject.SetActive(false);

            potion_on.gameObject.SetActive(true);
            potion_off.gameObject.SetActive(false);
            potion_number.gameObject.SetActive(true);

            etc_on.gameObject.SetActive(false);
            etc_off.gameObject.SetActive(true);
            etc_number.gameObject.SetActive(false);
        }
        else
        {
            inventory_potion_ui.SetActive(false);
            potion_on.gameObject.SetActive(false);
            potion_off.gameObject.SetActive(true);
        }

        if (inventory_etc_on)                             // ##### 기타 인벤창 활성시 #####
        {
            inventory_etc_ui.SetActive(true);
            inventory_weapon_ui.SetActive(false);
            inventory_potion_ui.SetActive(false);

            weapon_on.gameObject.SetActive(false);
            weapon_off.gameObject.SetActive(true);
            weapon_number.gameObject.SetActive(false);

            potion_on.gameObject.SetActive(false);
            potion_off.gameObject.SetActive(true);
            potion_number.gameObject.SetActive(false);

            etc_on.gameObject.SetActive(true);
            etc_off.gameObject.SetActive(false);
            etc_number.gameObject.SetActive(true);
        }
        else
        {
            inventory_etc_ui.SetActive(false);
            etc_on.gameObject.SetActive(false);
            etc_off.gameObject.SetActive(true);
        }
       
    }

    public void Open_inventory_weapon()                   // 무기 인벤창 비활성 버튼 클릭시
    {
        inventory_weapon_on = true;
        inventory_potion_on = false;
        inventory_etc_on = false;
    }

    public void Open_inventory_potion()                   // 물약 인베창 비활성 버튼 클릭시
    {
        inventory_weapon_on = false;
        inventory_potion_on = true;
        inventory_etc_on = false;
    }

    public void Open_inventory_etc()                      // 기타 인벤창 비활성 버튼 클릭시
    {
        inventory_weapon_on = false;
        inventory_potion_on = false;
        inventory_etc_on = true;
    }

    public void Exit_inventory()                       // 인벤토리 나가기 버튼
    {
        inventory.gameObject.SetActive(false);
    }
}
