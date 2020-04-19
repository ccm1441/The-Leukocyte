using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemGenerate : MonoBehaviour
{

    public float Respawntimer = 0.0f; //리스폰을 일정한 시간마다 시키기위한 타이머
    public bool onceOnly = false; // 한번만 생성하기 위한 불 변수
    public GameObject monster; // 몬스터 게임 오브젝트
    public GameObject item; // 아이템 프리팹
    private float monsterHP = 10f; // 몬스터 체력
    public ParticleSystem hit_effect;


    /*********************************************/
    /*                                           */
    /* 칼을 휘두를때만 콜라이더 켜주고 체력 깎음 */
    /*                                           */
    /*********************************************/

    private void Start()
    {
        hit_effect.Pause();

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Sword") && !onceOnly)
        {
            if (CharacterSwordBrandish.isBrandishing)
            {
                hit_effect.Play();
                monsterHP -= 2f;
            }
        }

        if (hit.CompareTag("InjectionBullet"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 3f * player_.player_info_attack;
        }

        if (hit.CompareTag("tamiflu"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 3.3f * player_.player_info_attack;
        }

        if (hit.CompareTag("penicillin"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 3.6f * player_.player_info_attack;
        }


        if (hit.CompareTag("tablet"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 4f * player_.player_info_attack;
        }

        if (hit.CompareTag("tablet2"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 4.5f * player_.player_info_attack;
        }
        if (hit.CompareTag("tablet3"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 4.8f * player_.player_info_attack;
        }

        if (hit.CompareTag("scissors"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 5.0f * player_.player_info_attack;
        }
        if (hit.CompareTag("Mes") && !onceOnly)
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 5f * player_.player_info_attack;
            }
        }
        if (hit.CompareTag("saw") && !onceOnly)
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 5f * player_.player_info_attack;
            }
        }

        if (hit.CompareTag("legendweapon"))
            {
            if (CharacterSwordBrandish.isBrandishing)
            {
                hit_effect.Play();
                monsterHP -= 10f * player_.player_info_attack;
            }
        }
    }
    /*********************************************/
    /*                                           */
    /*            칼 부분 구현 끝                */
    /*                                           */
    /*********************************************/

    /*********************************************/
    /*                                           */
    /*     몬스터가 죽었는지 체크하는 메서드     */
    /*                                           */
    /*********************************************/
    private void CheckDeath()
    {
        if (monsterHP <= 0.0f) // 몬스터 체력이 0작거나 같을때
        {
            monster.gameObject.GetComponent<SpriteRenderer>().enabled = false; // 스프라이트를 꺼줌
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            monster.gameObject.GetComponent<MonsterMove>().enabled = false;
            Respawntimer += Time.deltaTime;  // 리스폰 시간 계산을 위한 부분
            if (!onceOnly) // 아이템을 한번만 생성하기 위해서
            {
                onceOnly = true;
                Quest.monsterDie++;
                Instantiate(item, transform.position, Quaternion.identity);
                player_.player_info_exp += 10 * buff_.exp_mult;
                player_.player_info_money += 20;

            }
        }
        if (Respawntimer >= 2) // 리스폰 할 시간이 되면
        {
            onceOnly = false; // 아이템 생성이 다시 가능하게 함
            monsterHP = 10f; // 몬스터 체력 원래대로
            Respawntimer = 0.0f; // 리스폰 시간 초기화
            monster.gameObject.GetComponent<MonsterMove>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            monster.gameObject.GetComponent<SpriteRenderer>().enabled = true; // 스프라이트 켜줌
        }
    }
    public void DeathCount()
    {
        if (Quest.isclear[0] == false && Quest.questplaying[0] == true)
        {
            if (Quest.monsterDie >= 10)
            {
                Quest.isclear[0] = true;
            }
        }
    }
    /*********************************************/
    /*                                           */
    /*   몬스터가 죽었는지 체크하는 메서드 끝    */
    /*                                           */
    /*********************************************/
    void Update()
    {
        //monsterHP = 1f;
        CheckDeath();
        DeathCount();
    }

}
