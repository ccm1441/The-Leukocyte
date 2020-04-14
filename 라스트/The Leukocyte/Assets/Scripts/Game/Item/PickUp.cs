using UnityEngine;

public class PickUp : MonoBehaviour
{ // 이 스크립트는 아이템을 먹는 스크립트

    private Inventory inventory;                // 인벤토리 스크립트 사용

    static bool exit_for = false;               // for 문 탈출을 위한
    public Collider2D box;                      // 콜라이더 제어를 위한

    static bool weapon_overlap = false;         // 무기 인벤토리가 꽉참을 판단
    static bool potion_overlap = false;         // 포션 인벤토리가 꽉참을 판단
    static bool etc_overlap = false;            // 기타 인벤토리가 꽉참을 판단

    void Start()
    {
        // 인벤토리 스크립트 가져오기
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        // 각 인벤토리가 꽉찰시 아이템 콜라이더 off
        if (inventory_.weapon_items[8] == 1 && inventory_.weapon_items[7] == 1 && inventory_.weapon_items[6] == 1 && inventory_.weapon_items[5] == 1
            && inventory_.weapon_items[4] == 1 && inventory_.weapon_items[3] == 1 && inventory_.weapon_items[2] == 1 && inventory_.weapon_items[1] == 1
            && inventory_.weapon_items[0] == 1)
            box.enabled = false;
        else box.enabled = true;

        if (inventory_.potion_items[8] == 1 && inventory_.potion_items[7] == 1 && inventory_.potion_items[6] == 1 && inventory_.potion_items[5] == 1
            && inventory_.potion_items[4] == 1 && inventory_.potion_items[3] == 1 && inventory_.potion_items[2] == 1 && inventory_.potion_items[1] == 1
            && inventory_.potion_items[0] == 1)
            box.enabled = false;
        else box.enabled = true;

        if (inventory_.etc_items[8] == 1 && inventory_.etc_items[7] == 1 && inventory_.etc_items[6] == 1 && inventory_.etc_items[5] == 1
            && inventory_.etc_items[4] == 1 && inventory_.etc_items[3] == 1 && inventory_.etc_items[2] == 1 && inventory_.etc_items[1] == 1
            && inventory_.etc_items[0] == 1)
            box.enabled = false;
        else box.enabled = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 아이템에 플레이어가 들어오면 각 분류에 따라 함수 호출
        if (other.CompareTag("Player"))
        {
            if (this.CompareTag("potion"))
                check_potion(this.name,false);
            else if (this.CompareTag("weapon"))
                check_weapon(this.name,false);
            else if (this.CompareTag("etc"))
                check_etc(this.name, false);
        }
    }

    
    void add_weapon_items(int i,string name,bool check_market)
    { // 무기 아이템 추가
        if (inventory_.weapon_items[i] == 0)
        {   // 무기 아이템 배열의 인덱스가 0이면
            inventory_.weapon_items[i] = 1;                                    // 1을 넣어 아이템이 있음을 알림
            inventory_.weapon_name[i] = name;                                  // 또다른 배열에 아이템 이름 대입
            for (int j = 0; j < inventory.weapon_item.Length; j++)       // 인벤토리에 그림 표현
            {
                if (inventory_.weapon_name[i] == inventory.weapon_item[j].name)// 현재 무기이름이랑 오브젝트 이름이랑 같으면
                {       // 인벤토리에 프리팹을 생성하여 아이템이 있음을 알려줌
                    Instantiate(inventory.weapon_item[j], inventory_.weapon_slots[i].transform, false);
                    inventory_.weapon_items_number[i]++;                       // 현재 가지고 있는 아이템의 갯수를 더함
                    if (inventory_.weapon_item_object[i] == null)              // 맵간의 공유를 위해 해당 칸의 오브젝트 저장
                        inventory_.weapon_item_object[i] = inventory.weapon_item[j]; // 공유전용 배열에 현재 오브젝트 저장
                    if(!check_market)Destroy(gameObject);                // 마켓에서 산거와 다르게 파괴
                    exit_for = true;                                     // 반복문 탈출
                    break;
                }
            }
        }
    }

    void add_potion_items(int i, string name, bool check_market)
    { // 위에 무기 아이템 추가함수랑 똑같음
        if (inventory_.potion_items[i] == 0)
        {
            inventory_.potion_items[i] = 1;
            inventory_.potion_name[i] = name;
            for (int j = 0; j < inventory.potion_item.Length; j++)
            {
                if (inventory_.potion_name[i] == inventory.potion_item[j].name)
                {
                    Instantiate(inventory.potion_item[j], inventory_.potion_slots[i].transform, false);
                    inventory_.potion_items_number[i]++;
                    if (inventory_.potion_item_object[i] == null)
                        inventory_.potion_item_object[i] = inventory.potion_item[j];
                    if (!check_market) Destroy(gameObject);
                    exit_for = true;
                    break;
                }
            }
        }
    }

    void add_etc_items(int i,string name, bool check_market)
    {  // 위에 무기 아이템 추가함수랑 똑같음
        if (inventory_.etc_items[i] == 0)
        {
            inventory_.etc_items[i] = 1;
            inventory_.etc_name[i] = name;
            for (int j = 0; j < inventory.etc_item.Length; j++)
            {
                if (inventory_.etc_name[i] == inventory.etc_item[j].name)
                {               
                    Instantiate(inventory.etc_item[j], inventory_.etc_slots[i].transform, false);
                    inventory_.etc_items_number[i]++;
                    if (inventory_.etc_item_object[i] == null)
                        inventory_.etc_item_object[i] = inventory.etc_item[j];
                    if (!check_market) Destroy(gameObject);
                    exit_for = true;
                    break;
                }
            }
        }
    }

    public void check_weapon(string name, bool check_market)
    { // 무기아이템 중복 체크
        for (int i = 0; i < inventory_.weapon_items.Length; i++)
        {                                                       // 무기 아이템이 중복이라면
            if (inventory_.weapon_name[i] == name)
            { 
                inventory_.weapon_items_number[i]++;                  // 해당 무기 아이템 +1
                if (!check_market) Destroy(gameObject);                        // 먹은거 삭제
                break;
            }
            else
            {
                add_weapon_items(i,name,check_market);          // 중복이 아니면 새로운 아이템 추가
                if (exit_for)
                {
                    exit_for = false;                           // 반복문 탈출
                    break;
                }
            }
        }
    }

    public void check_potion(string name, bool check_market)
    { // 위에 무기 중복함수랑 똑같음
        for (int i = 0; i < inventory_.potion_items.Length; i++)
        {
            if (inventory_.potion_name[i] == name)
            {
                inventory_.potion_items_number[i]++;
                if (!check_market) Destroy(gameObject);
                break;
            }
            else
            {
                add_potion_items(i,name,check_market);
                if (exit_for)
                {
                    exit_for = false;
                    break;
                }
            }
        }
    }

    public void check_etc(string name, bool check_market)
    {  // 위에 무기 중복함수랑 똑같음
        for (int i = 0; i < inventory_.etc_items.Length; i++)
        {
            if (inventory_.etc_name[i] == name)
            {
                inventory_.etc_items_number[i]++;
                if (!check_market) Destroy(gameObject);
                break;
            }
            else
            {
                add_etc_items(i, name, check_market);              
                if (exit_for)
                {
                    exit_for = false;
                    break;
                }
            }
        }
    }

}


