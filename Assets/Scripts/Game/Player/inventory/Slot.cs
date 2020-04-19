using UnityEngine;

public class Slot : MonoBehaviour                                      // ##### 각 슬롯마다 넣음 #####
{

    private Inventory inventory;                                       // 인벤토리 스크립트 참조
    public int i;                                                      // 각 슬롯에 번호를 부여


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // 플레이어 태그가진 오브젝트에서 인벤토리 겟

    }

    private void FixedUpdate()
    {
        if (transform.GetChildCount() > 0 && inventory.inventory_weapon_ui.activeSelf)
        { //조합 후 아이템 삭제
            if (inventory_.weapon_items_number[i] == 0 && inventory_.weapon_item_object != null)
            {
                Destroy(GameObject.Find(inventory_.weapon_slots[i].name).transform.GetChild(0).gameObject);

            }
        }
        if (transform.GetChildCount() > 0 && inventory.inventory_etc_ui.activeSelf)
        { //조합 후 아이템 삭제
            if (inventory_.etc_items_number[i] == 0 && inventory_.etc_item_object != null)
            {
                Destroy(GameObject.Find(inventory_.etc_slots[i].name).transform.GetChild(0).gameObject);
                inventory_.etc_items[i] = 0;
                inventory_.etc_name[i] = null;
                inventory_.etc_item_object[i] = null;
            }
        }

    }

    public void sell_item()
    {
        if (inventory.inventory_potion_ui.activeSelf && inventory_.potion_items_number[i] > 0)
        {
            inventory_.potion_items_number[i]--;
            player_.player_info_money += 100;
            if (inventory_.potion_items_number[i] == 0)
            {
                inventory_.potion_items[i] = 0;
                inventory_.potion_item_object[i] = null;
                inventory_.potion_name[i] = null;
                Destroy(transform.GetChild(0).gameObject);
            }
        }

        if (inventory.inventory_etc_ui.activeSelf && inventory_.etc_items_number[i] > 0)
        {
            inventory_.etc_items_number[i]--;
            player_.player_info_money += 100;
            if (inventory_.etc_items_number[i] == 0)
            {
                inventory_.etc_items[i] = 0;
                inventory_.etc_item_object[i] = null;
                inventory_.etc_name[i] = null;
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }


}
