using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combine : MonoBehaviour
{

    public PickUp pickup;                              // pickup 스크립트 사용     

    public GameObject combin_ui;
    public Text material1;
    public Text material2;
    public Text material3;
    public string[] material;
    public GameObject sold_out;
    public GameObject less_me;
    public Text use;
    public static bool hasLegend = false;
    static int[] material_n = new int[3];
    static int[] material_pos = new int[3];


    // Use this for initialization
    void Start()
    {
        combin_ui.gameObject.SetActive(false);
        sold_out.gameObject.SetActive(false);
        less_me.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Quest.iscomplete[5] == true)
            {
                combin_ui.SetActive(true);
                set_material();
            }
        }

    }

    private void FixedUpdate()
    {
        if (!market_.combian_use)
        {
            if (material_n[0] >= 1 && material_n[1] >= 1 && material_n[2] >= 4)
                less_me.gameObject.SetActive(false);
            else less_me.gameObject.SetActive(true);
        }
        else
        {
            sold_out.SetActive(true);
            less_me.SetActive(true);
            use.text = "You've already used this!!";
        }

    }

    void set_material()
    {
        for (int i = 0; i < inventory_.etc_items.Length; i++)
        {

            if (inventory_.etc_items[i] == 1 && inventory_.etc_name[i] == material[0])
            {
                material1.text = inventory_.etc_items_number[i] + " / 1";
                material_n[0] = inventory_.etc_items_number[i];
                material_pos[0] = i;
                continue;
            }
            if (inventory_.etc_items[i] == 1 && inventory_.etc_name[i] == material[1])
            {
                material2.text = inventory_.etc_items_number[i] + " / 1";
                material_n[1] = inventory_.etc_items_number[i];
                material_pos[1] = i;
                continue;
            }
            if (inventory_.etc_items[i] == 1 && inventory_.etc_name[i] == material[2])
            {
                material3.text = inventory_.etc_items_number[i] + " / 4";
                material_n[2] = inventory_.etc_items_number[i];
                material_pos[2] = i;
                continue;
            }
        }
    }

    public void combin()
    {
        if (material_n[0] >= 1 && material_n[1] >= 1 && material_n[2] >= 4)
        {
            pickup.check_weapon("Surgical_Knife", true);           // 아이템 인벤토리 저장  
            hasLegend = true;
            inventory_.etc_items_number[material_pos[0]]--;
            inventory_.etc_items_number[material_pos[1]]--;
            inventory_.etc_items_number[material_pos[2]] -= 4;
            set_material();
            sold_out.SetActive(true);
            market_.combian_use = true;
        }
    }


    public void exit()
    {
        combin_ui.gameObject.SetActive(false);
    }
}
