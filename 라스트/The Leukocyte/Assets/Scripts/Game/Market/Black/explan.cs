using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class explan : MonoBehaviour
{// 암상인 아이템 구매

    public PickUp pickup;                              // pickup 스크립트 사용  
    public black black;
    public showtext showtext;

    public GameObject black_explan;
    public GameObject black_mouse;



    // Use this for initialization
    void Start()
    {
        black_explan.gameObject.SetActive(false);
        black_mouse.gameObject.SetActive(false);
        showtext.black_explan_t.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && market_.mouse_over && !market_.black_buy)
        {
            for (int i = 0; i < inventory_.etc_slots.Length; i++)
            {
                if (inventory_.etc_name[i] == "Monster_DropItem(Clone)")
                {
                    if (inventory_.etc_items_number[i] >= 10)
                    {
                        pickup.check_etc("fragmentation", true);                             // 아이템 인벤토리 저장         
                        market_.success_buy = true;                        // 구매 성공
                        market_.black_buy = true;
                        inventory_.etc_items_number[i] -= 10;
                        inventory_.etc_name[i] = null;
                    }
                }
            }
        }

        if (market_.success_buy)
        {
            market_.success_buy = false;
            showtext.black_explan_t.gameObject.SetActive(false);
            black.black_exit.gameObject.SetActive(false);
            black.black_ui.gameObject.SetActive(false);
        }

    }

    private void OnMouseOver()
    {
        black_explan.gameObject.SetActive(true);
        black_mouse.gameObject.SetActive(true);
        showtext.black_explan_t.gameObject.SetActive(true);
        market_.mouse_over = true;
    }

    private void OnMouseExit()
    {
        black_explan.gameObject.SetActive(false);
        black_mouse.gameObject.SetActive(false);
        showtext.black_explan_t.gameObject.SetActive(false);
        market_.mouse_over = false;
    }
}
