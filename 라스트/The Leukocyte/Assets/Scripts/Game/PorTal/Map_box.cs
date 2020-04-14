using UnityEngine;

[System.Serializable]
public static class player_  // 플레이어 정보 
{  
    public static int player_info_money = 3000;                         // 플레이어 돈
    public static int player_info_level = 1;                         // 플레이어 레벨
    public static int player_info_exp =0;                           // 플레이어 경험치
    public static int player_info_hp = 100;                          // 플레이어 체력
    public static float player_info_attack = 1;                      // 플레이어 공격력
    public static string player_info_nick = null;                           // 플레이어 닉네임    
    public static bool player_left = false;
    public static bool player_right = false;
    public static string before_class = null;
}

[System.Serializable]
public static class inventory_  // 인벤토리 정보
{   
    public static bool get_inventory_pos = false;                    // 인벤토리 위치 얻을것인가
    public static float inventory_x;                                 // 인벤토리 x좌표
    public static float inventory_y;                                 // 인벤토리 y좌표

    public static int[] weapon_items = new int[9];                   // 무기 아이템 있음 1 없음 0 판단위함
    public static int[] potion_items = new int[9];                   // 물약 아이템 있음 1 없음 0 판단위함
    public static int[] etc_items = new int[9];                      // 기타 아이템 있음 1 없음 0 판단위함

    public static GameObject[] weapon_slots = new GameObject[9];     // 무기 슬롯
    public static GameObject[] potion_slots = new GameObject[9];     // 물약 슬롯
    public static GameObject[] etc_slots = new GameObject[9];        // 기타 슬롯
    public static bool first_slot_setting = false;                   // 최초 1번맵에서 인벤셋팅

    public static string[] weapon_name = new string[9];              // 무기 아이템 이름
    public static GameObject[] weapon_item_object = new GameObject[9];// 무기 아이템 오브젝트(씬간 공유)
    public static string[] potion_name = new string[9];              // 물약 아이템 이름
    public static GameObject[] potion_item_object = new GameObject[9];// 물약 아이템 오브젝트(씬간 공유)
    public static string[] etc_name = new string[9];                 // 기타 아이템 이름
    public static GameObject[] etc_item_object = new GameObject[9];  // 기타 아이템 오브젝트(씬간 공유)

    public static int[] weapon_items_number = new int[9];            // 무기 아이템 개수
    public static int[] potion_items_number = new int[9];            // 포션 아이템 개수
    public static int[] etc_items_number = new int[9];               // 기타 아이템 개수

    public static int set_slot = 0;                                  // 씬간 슬롯 재 배치 
    public static bool reset_set_slot = false;                       // 위에 값 초기화

    public static bool hasWeapon1 = false;
    public static bool hasWeapon2 = false;
    public static bool hasWeapon3 = false;
    public static bool hasWeapon4 = false;
    public static bool hasWeapon5 = false;
    public static bool hasWeapon6 = false;
}

[System.Serializable]
public static class market_  // 마켓 정보
{
    public static GameObject[] Armory = new GameObject[9];           // 무기상점 목록
    public static GameObject[] Potion = new GameObject[9];           // 무기상점 목록
    public static string current_select_item = null;                 // 현재 무기상점에서 선택한것
    public static bool enter_market = false;                         // 지정 지역에서만 구매가능하도록
    public static bool success_buy = false;                          // 구매 성공

    public static bool black_use = false;                            // 암상인 1회 이용 여부
    public static bool black_buy = false;                            // 암상인 1회 구매 여부

    public static bool combian_use = false;                          // 조합상인 사용 여부

    public static bool mouse_over = false;                           // 마우스  오버시 구매 가능
}

[System.Serializable]
public static class map_  // 맵 정보
{   
    public static bool left_check = false;                           // 왼쪽 포탈을 이용했다는 것을 인식
    public static bool right_check = false;                          // 오른쪽 포탈을 이용했다는 것을 인식
    public static bool up_check = false;                             // 왼쪽 포탈을 이용했다는 것을 인식
    public static bool down_check = false;                           // 오른쪽 포탈을 이용했다는 것을 인식

    public static string scene_name = null;                          // 현재 위치하고있는 씬 이름

    public static string left_map;                                   // 포탈을 이용할시 왼쪽으로 이동할 맵이름
    public static string right_map;                                  // 포탈을 이용할시 오른쪽으로 이동할 맵이름
    public static string up_map;                                     // 포탈을 이용할시 위로 이동할 맵이름
    public static string down_map;                                   // 포탈을 이용할시 아래로 이동할 맵이름
    public static string hidden_map;                                 // 포탈을 이용할시 히든맵으로 이동할 맵이름

    public static bool map_check = false;                            // 맵이 바뀌었는것을 인식
    public static bool animation_off = false;                        // 맵1 에서 최초 한번만 애니 실행하도록
    public static bool town_off = false;                             // 처음 웅성웅성 마을을 나가면 다음에는 일반 마을 소환

    // ##### 맵 이동시 플레이어 좌표를 포탈 좌표 +- 설정
    public static float portal_position_left;                        // 왼쪽
    public static float portal_position_right;                       // 오른쪽
    public static float portal_position_up;                          // 위
    public static float portal_position_down;                        // 아래  

    public static int load_map = -1;
}

[System.Serializable]
public static class buff_  // 버프 정보
{   
    public static bool use_exp;
    public static float exp_time = 0;
    public static float time = 0;
    public static int exp_mult = 50;
}

public static class sound_
{
    public static AudioSource sowrd_sound;
    public static AudioSource throw1_sound;
    public static AudioSource throw2_sound;
    public static AudioSource level_sound;
}

