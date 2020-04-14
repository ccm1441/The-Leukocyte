using UnityEngine;
using UnityEngine.SceneManagement;

public class Set_slot : MonoBehaviour
{
    private Inventory inventory;                    // 인벤토리 스크립트 참조
    private Slot slot;                              // 슬롯 스크립트 참조
    Scene scene;                                    // 씬 정의

    private GameObject inventory_object;            // 인벤토리 오브젝트 정의
    private GameObject weapon_slot_object;          // 포션 슬롯 오브젝트 정의
    private GameObject potion_slot_object;          // 포션 슬롯 오브젝트 정의
    private GameObject etc_slot_object;             // 기타 슬롯 오브젝트 정의

    bool exit_slot = false;                         // 슬롯 재배치 판별


    void Start()
    {
        scene = SceneManager.GetActiveScene();      // 씬 네임 불러오기 위해
                                                    // 플레이어에 들어간 인벤스크립트 가져옴
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        // 각 슬롯 찾음
        inventory_object = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        weapon_slot_object = inventory_object.transform.Find("inventory_weapon_slot").gameObject;
        potion_slot_object = inventory_object.transform.Find("inventory_potion_slot").gameObject;
        etc_slot_object = inventory_object.transform.Find("inventory_etc_slot").gameObject;

        Set();                                      // 함수호출

    }

    private void Update()
    {
        // 총 9개의 슬롯이 배치가 완료 될때까지 배치함수 실행
        if (inventory_.set_slot != 9 && inventory_.reset_set_slot && !exit_slot)
        {
            exit_slot = true;
            Set();
        }
    }

    public void Set()
    {
        if (!inventory_.reset_set_slot && (scene.name != map_.scene_name || scene.name == map_.scene_name))
        {  // 맵이 바뀌면 슬롯 재설정
            inventory_.set_slot = 0;
            inventory_.reset_set_slot = true;
        }

        slot = GameObject.Find("Slot" + inventory_.set_slot).GetComponent<Slot>();

        if (inventory_.set_slot == slot.i)
        {    // ######## 슬롯 재배치 실시 #######
                inventory_.weapon_slots[slot.i] = weapon_slot_object.transform.Find("w_InventorySlot" + slot.i).transform.Find("Slot" + slot.i.ToString()).gameObject;
                inventory_.potion_slots[slot.i] = potion_slot_object.transform.Find("p_InventorySlot" + slot.i).transform.Find("Slot" + slot.i.ToString()).gameObject;
                inventory_.etc_slots[slot.i] = etc_slot_object.transform.Find("e_InventorySlot" + slot.i).transform.Find("Slot" + slot.i.ToString()).gameObject;

            // ######## 슬롯 재배치 끝 #######

            // ######## 인벤토리 아이템 불러오기 #######
            for (int j = 0; j < inventory_.weapon_item_object.Length; j++)
            {
                if (inventory_.weapon_name[slot.i] != null)
                    if (inventory_.weapon_name[slot.i] == inventory_.weapon_item_object[j].name && inventory_.weapon_items[slot.i] == 1)
                    {
                        Instantiate(inventory_.weapon_item_object[j], inventory_.weapon_slots[slot.i].transform, false);
                        break;
                    }
            }

            for (int j = 0; j < inventory_.potion_item_object.Length; j++)
            {
                if (inventory_.potion_name[slot.i] != null)
                    if (inventory_.potion_name[slot.i] == inventory_.potion_item_object[j].name && inventory_.potion_items[slot.i] == 1)
                    {
                        Instantiate(inventory_.potion_item_object[j], inventory_.potion_slots[slot.i].transform, false);
                        break;
                    }
            }

            for (int j = 0; j < inventory_.etc_item_object.Length; j++)
            {
                if (inventory_.etc_name[slot.i] != null)
                    if (inventory_.etc_name[slot.i] == inventory_.etc_item_object[j].name && inventory_.etc_items[slot.i] == 1)
                    {
                        Instantiate(inventory_.etc_item_object[j], inventory_.etc_slots[slot.i].transform, false);
                        break;
                    }
            }
            // ######## 인벤토리 아이템 불러오기 끝 #######

            // 슬롯 번호 +1
            inventory_.set_slot++;

            //슬롯 배치 끝남
            if (inventory_.set_slot == 9)
            {
                exit_slot = false;
                inventory_.reset_set_slot = false;
            }
        }
    }
}
