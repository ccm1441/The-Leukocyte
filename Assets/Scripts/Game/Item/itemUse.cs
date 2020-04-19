using UnityEngine;
using UnityEngine.UI;

public class itemUse : MonoBehaviour
{
    private Inventory inventory;                                            // 인벤토리스크립트 참조
    private Slot slot;                                                      // 슬롯스크립트 참조

    private Text score_text;                                                // 테스트용

    public GameObject effect;                                               // 아이템 사용시 이펙트
    public GameObject hp_effect;
    private Transform player;                                               // 이펙트 좌표설정을 위한 플레이어

  
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();   

    }

    public void Use()                                                       // ##### 아이템 사용 #####
    {
        slot = transform.parent.GetComponent<Slot>();                       // 아이템 부모컴포넌트의 슬롯스크립트 찾아옴

        if (CompareTag("weapon"))
        {           
         inventory_.weapon_items_number[slot.i]--;                                // 아이템 갯수에서 -1

          if(inventory_.weapon_items_number[slot.i] == 0)                         // 아이템 갯수가 0이면
            {
                inventory_.weapon_items[slot.i] = 0;                              // 해당 칸에 아이템 없음을 표현
                inventory_.weapon_name[slot.i] = null;                            // 해당칸 아이템 이름 초기화
                Destroy(gameObject);                                        // 해당칸 아이템 파괴
            }      

        }
        else if (CompareTag("potion"))
        { // 무기랑 같음
            inventory_.potion_items_number[slot.i]--;

            if (inventory_.potion_name[slot.i] == "potion1")
            { // 체력포션
                Instantiate(hp_effect, new Vector2(player.position.x, player.position.y - 0.5f), hp_effect.transform.rotation);
                player_.player_info_hp += 40;
            }
            else if (inventory_.potion_name[slot.i] == "potion0")
            { // 경험치포션
                buff_.use_exp = true;
                buff_.exp_time += 15;
                buff_.exp_mult = 50;
            }
                           

            if (inventory_.potion_items_number[slot.i] == 0)
            {
                inventory_.potion_items[slot.i] = 0;
                inventory_.potion_name[slot.i] = null;
                Destroy(gameObject);
            }
          
        }           
        else if (CompareTag("etc"))
        {  // 무기랑 같음
            inventory_.etc_items_number[slot.i]--;

            if (inventory_.etc_items_number[slot.i] == 0)
            {
                inventory_.etc_items[slot.i] = 0;
                inventory_.etc_name[slot.i] = null;
                Destroy(gameObject);
            }
        }
    }
}
// instantiate 함수
// 오브젝트를 복사한다. 
// instantiate(생성하고자하는 오브젝트or프리팹, 생성할 위치, 생성된 오브젝트의 회전값)
// 회전값은 Quaternion.identity 이 기본값이다. 회전안함.