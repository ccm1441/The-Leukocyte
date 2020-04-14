using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    //세이브 할 내용을 미리 선언해주고 매니저가서 직접 값 대입해주세여

    //세이브 장소
    public int save_home;                                     // 0 = 골수마을 집 , 1 = 모세혈관 집

    //캐릭터 정보
    public int lavel;                                         // 레벨
    public string nickname;                                   // 닉네임
    public int hp;                                            // 체력
    public int exp;                                           // 경험치
    public int money;                                         // 돈
    public float attack;                                      // 공격력

    //맵 관련
    public bool animation_off;
    public bool first_slot_setting;
    public bool town_off;

    //인벤토리 아이템
    public int[] weapon_items = new int[9];                   // 무기 아이템 있음 1 없음 0 판단위함
    public int[] potion_items = new int[9];                   // 물약 아이템 있음 1 없음 0 판단위함
    public int[] etc_items = new int[9];                      // 기타 아이템 있음 1 없음 0 판단위함

    public string[] weapon_name = new string[9];              // 무기 아이템 이름
    public string[] potion_name = new string[9];              // 물약 아이템 이름
    public string[] etc_name = new string[9];                 // 기타 아이템 이름

    public int[] weapon_items_number = new int[9];            // 무기 아이템 개수
    public int[] potion_items_number = new int[9];            // 포션 아이템 개수
    public int[] etc_items_number = new int[9];               // 기타 아이템 개수


    public bool hasWeapon1;
    public bool hasWeapon2;
    public bool hasWeapon3;
    public bool hasWeapon4;
    public bool hasWeapon5;
    public bool hasWeapon6;

    //퀘스트
    public int monsterDie = 0;
    public bool[] questplaying = new bool[10];
    public bool[] isclear = new bool[10];
    public bool[] iscomplete = new bool[10];
    public bool[] viewing = new bool[10];
}
