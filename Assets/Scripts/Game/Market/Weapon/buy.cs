using UnityEngine;
using UnityEngine.UI;

public class buy : MonoBehaviour
{
    // 이 스크립트는 아이템 구매 스크립트

    public PickUp pickup;                              // pickup 스크립트 사용     
    public GameObject Market_item_explain;             // 아이템 설명창 사용
    public Text explain_text;                        
    public int item_num;                               // 각 아이템 마다 고유 숫자 부여
       

    void Start()
    {   // 각 아이템을 배열 인덱스에 저장
        if(GameObject.Find("Weapon"))
        market_.Armory[item_num] = GameObject.Find("Weapon").transform.Find("Weapon" + item_num).gameObject;
        else if(GameObject.Find("potion"))
            market_.Potion[item_num] = GameObject.Find("potion" + item_num).gameObject;
          
    }

    private void FixedUpdate()
    {
        if (market_.current_select_item == this.name && market_.mouse_over)
            explain_text.gameObject.SetActive(true);
        else if (!market_.mouse_over) explain_text.gameObject.SetActive(false);

        if (GameObject.Find("Weapon"))
        {
            if (Input.GetMouseButton(0) && market_.current_select_item == this.name && market_.mouse_over && market_.enter_market)
            {
                if((name == "Weapon1" || name == "Weapon2") && player_.player_info_level >=9)
                { //의사                   
                    if (name == "Weapon1" && player_.player_info_money >= 1500 && !inventory_.hasWeapon1)
                    {
                        player_.player_info_money -= 1500;
                        inventory_.hasWeapon1 = true;
                    }
                
                    if (name == "Weapon2" && player_.player_info_money >= 2000 && !inventory_.hasWeapon2)
                    {
                        player_.player_info_money -= 2000;
                        inventory_.hasWeapon2 = true;
                    }
                    explain_text.gameObject.SetActive(false);
                    Destroy(this.gameObject);                       // 진열품 삭제
                }
                if ((name == "Weapon3" || name == "Weapon4") && player_.player_info_level >= 4 && player_.player_info_level <= 6)
                { //간호사
                    if (name == "Weapon3" && player_.player_info_money >= 1500 && !inventory_.hasWeapon3)
                    {
                        player_.player_info_money -= 1500;
                        inventory_.hasWeapon3 = true;
                    }
                   
                    if (name == "Weapon4" && player_.player_info_money >= 2000 && !inventory_.hasWeapon4)
                    {
                        player_.player_info_money -= 2000;
                        inventory_.hasWeapon4 = true;
                    }
                    explain_text.gameObject.SetActive(false);
                    Destroy(this.gameObject);                       // 진열품 삭제
                }
                if ((  name == "Weapon5" || name == "Weapon6") && player_.player_info_level >= 7 && player_.player_info_level <= 9)
                { //약사
                    if (name == "Weapon5" && player_.player_info_money >= 1500 && !inventory_.hasWeapon5)
                    {
                        player_.player_info_money -= 1500;
                        inventory_.hasWeapon5 = true;
                    }
                   
                    if (name == "Weapon6" && player_.player_info_money >= 2000 && !inventory_.hasWeapon6)
                    {
                        player_.player_info_money -= 2000;
                        inventory_.hasWeapon6 = true;
                    }
                   
                    explain_text.gameObject.SetActive(false);
                    Destroy(this.gameObject);                       // 진열품 삭제
                }
            }
        }

        if (GameObject.Find("potion"))
        {        
            if (Input.GetMouseButtonDown(0) && market_.current_select_item == this.name && market_.mouse_over && market_.enter_market)
            {
                if (name == "potion0" && player_.player_info_money >= 100)
                    player_.player_info_money -= 100;
              

                if (name == "potion1" && player_.player_info_money >= 50)
                    player_.player_info_money -= 50; // 구매시 금액 차감
               

                pickup.check_potion(this.name, true);           // 아이템 인벤토리 저장 
                explain_text.gameObject.SetActive(false);
                market_.success_buy = true;                        // 구매 성공
               
            }
        }
       
    }
}
