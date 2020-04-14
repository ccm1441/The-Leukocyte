using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_start : MonoBehaviour {

    public PickUp pickup;
    private Inventory inventory;

    static bool get_first = false;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();   
	}
	
	// Update is called once per frame
	void Update () {

        if (inventory.inventory_etc_ui && !get_first)
        {
            for (int i = 0; i < 3; i++)
            {
                pickup.check_potion("potion0", true);
                pickup.check_potion("potion1", true);
            }
            get_first = true;
        }
    }
}
