using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sell : MonoBehaviour
{
    private Inventory inventory;

    public GameObject[] p_sell_button;
    public GameObject[] e_sell_button;

    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void FixedUpdate()
    {

        for (int i = 0; i < inventory_.etc_items.Length; i++)
        {
            if (inventory.inventory.activeSelf)
            {
                if (inventory_.etc_items[i] == 1 && inventory.inventory_etc_ui.activeSelf && market_.enter_market)
                    e_sell_button[i].gameObject.SetActive(true);
                else if ((!inventory.inventory_etc_ui.activeSelf || inventory_.etc_items[i] == 0))
                    e_sell_button[i].gameObject.SetActive(false);

                if (inventory_.potion_items[i] == 1 && inventory.inventory_potion_ui.activeSelf && market_.enter_market)
                    p_sell_button[i].gameObject.SetActive(true);
                else if (!inventory.inventory_potion_ui.activeSelf || inventory_.potion_items[i] == 0)
                    p_sell_button[i].gameObject.SetActive(false);
            }
            else
            {
                e_sell_button[i].gameObject.SetActive(false);
                p_sell_button[i].gameObject.SetActive(false);
            }

        }


    }
}

