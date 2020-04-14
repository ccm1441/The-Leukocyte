using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsSubBoss : MonoBehaviour {

    public GameObject lungsSubBoss; // 몬스터 게임 오브젝트
    public bool onceOnly = false;
    public GameObject subBossItem;
    public float monsterHP = 1f; // 몬스터 체력
    public ParticleSystem hit_effect;


    private void Start()
    {
        hit_effect.Pause();
    }

    /*********************************************/
    /*                                           */
    /* 칼을 휘두를때만 콜라이더 켜주고 체력 깎음 */
    /*                                           */
    /*********************************************/

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Sword") && !onceOnly)
        {
            if (CharacterSwordBrandish.isBrandishing)
            {
                hit_effect.Play();
                monsterHP -= 0.1f;
            }
        }

        if (hit.CompareTag("InjectionBullet"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.11f * player_.player_info_attack;
        }

        if (hit.CompareTag("tamiflu"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.12f * player_.player_info_attack;
        }

        if (hit.CompareTag("penicillin"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.13f * player_.player_info_attack;
        }


        if (hit.CompareTag("tablet"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.14f * player_.player_info_attack;
        }

        if (hit.CompareTag("tablet2"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.15f * player_.player_info_attack;
        }
        if (hit.CompareTag("tablet3"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.2f * player_.player_info_attack;
        }

        if (hit.CompareTag("scissors"))
        {
            Destroy(hit.gameObject);
            monsterHP -= 0.23f * player_.player_info_attack;
        }
        if (hit.CompareTag("Mes") && !onceOnly)
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 0.25f * player_.player_info_attack;
            }
        }
        if (hit.CompareTag("saw") && !onceOnly)
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 0.3f * player_.player_info_attack;
            }
        }

        if (hit.CompareTag("legendweapon"))
        {
            if (CharacterSwordBrandish.isBrandishing)
            {
                hit_effect.Play();
                monsterHP -= 0.31f * player_.player_info_attack;
            }
        }
        else if (hit.CompareTag("PlayerBody"))
        {
            player_.player_info_hp -= 10;
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
            if (!onceOnly)
            {

                Instantiate(subBossItem, transform.position, Quaternion.identity);

                onceOnly = true;
            }
            lungsSubBoss.SetActive(false);
            if(Quest.questplaying[2] == true)
            {
                Quest.isclear[2] = true;
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
    }

}
