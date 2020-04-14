using UnityEngine;
using UnityEngine.UI;

public class item_numbers : MonoBehaviour
{  // 이 스크립트는 아이템 숫자 를 표현하는 스크립트

    public int slot_n;                          // 각 슬롯의 갯수마다 고유 번호 부여

    public GameObject inventory;                // 인벤 오브젝트 

    public GameObject w_part;                     // 인벤 안 캔버스 오브젝트
    public Image w_back;                        // 무기 갯수 백그라운드
    public Text w_num;                          // 무기 갯수 텍스트

    public GameObject p_part;                     // 인벤 안 캔버스 오브젝트
    public Image p_back;                        // 무기 갯수 백그라운드
    public Text p_num;                          // 무기 갯수 텍스트

    public GameObject e_part;                     // 인벤 안 캔버스 오브젝트
    public Image e_back;                        // 무기 갯수 백그라운드
    public Text e_num;                          // 무기 갯수 텍스트

    void Start()
    {
        // 각 오브젝트 설정
        inventory = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;

        w_part = inventory.transform.Find("number").transform.Find("weapon").gameObject;
        w_back = w_part.transform.Find("w_back_slot" + slot_n).GetComponent<Image>();
        w_num = w_back.transform.Find("w_num_slot" + slot_n).GetComponent<Text>();

        p_part = inventory.transform.Find("number").transform.Find("potion").gameObject;
        p_back = p_part.transform.Find("p_back_slot" + slot_n).GetComponent<Image>();
        p_num = p_back.transform.Find("p_num_slot" + slot_n).GetComponent<Text>();

        e_part = inventory.transform.Find("number").transform.Find("etc").gameObject;
        e_back = e_part.transform.Find("e_back_slot" + slot_n).GetComponent<Image>();
        e_num = e_back.transform.Find("e_num_slot" + slot_n).GetComponent<Text>();

        // 맵이 바꼈을시 갯수 불러오기
        // ##### 아이템 겟수 뒷배경 설정
        // 아이템이 있으면 갯수 표현 후 뒷배경 처리
        // 아이템이 없으면 투명색으로 처리
        if (inventory_.weapon_items[slot_n] != 0)
        {
            w_back.color = new Color(0, 0, 0, 0.4f);
            w_num.text = inventory_.weapon_items_number[slot_n].ToString();
        }
        else
        {
            w_back.color = new Color(0, 0, 0, 0);
            w_num.text = "";
        }

        if (inventory_.potion_items[slot_n] != 0)
        {
            p_back.color = new Color(0, 0, 0, 0.4f);
            p_num.text = inventory_.potion_items_number[slot_n].ToString();
        }
        else
        {
            p_back.color = new Color(0, 0, 0, 0);
            p_num.text = "";
        }

        if (inventory_.etc_items[slot_n] != 0)
        {
            e_back.color = new Color(0, 0, 0, 0.4f);
            e_num.text = inventory_.etc_items_number[slot_n].ToString();
        }
        else
        {
            e_back.color = new Color(0, 0, 0, 0);
            e_num.text = "";
        }

    }

    private void FixedUpdate()
    {
        // ##### 아이템 겟수 뒷배경 설정
        // 아이템이 있으면 갯수 표현 후 뒷배경 처리
        // 아이템이 없으면 투명색으로 처리
        if (inventory_.weapon_items_number[slot_n] > 0)
        {
            w_back.color = new Color(0, 0, 0, 0.4f);
            w_num.text = inventory_.weapon_items_number[slot_n].ToString();
        }
        else if (inventory_.weapon_items_number[slot_n] == 0)
        {
            w_back.color = new Color(0, 0, 0, 0);
            w_num.text = "";
        }

        if (inventory_.potion_items_number[slot_n] > 0)
        {
            p_back.color = new Color(0, 0, 0, 0.4f);
            p_num.text = inventory_.potion_items_number[slot_n].ToString();
        }
        else if (inventory_.potion_items_number[slot_n] == 0)
        {
            p_back.color = new Color(0, 0, 0, 0);
            p_num.text = "";
        }

        if (inventory_.etc_items_number[slot_n] > 0)
        {
            e_back.color = new Color(0, 0, 0, 0.4f);
            e_num.text = inventory_.etc_items_number[slot_n].ToString();
        }
        else if (inventory_.etc_items_number[slot_n] == 0)
        {
            e_back.color = new Color(0, 0, 0, 0);
            e_num.text = "";
        }
    }

}
