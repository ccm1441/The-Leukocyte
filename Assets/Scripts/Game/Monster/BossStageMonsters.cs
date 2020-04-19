using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageMonsters : MonoBehaviour
{
    public float monsterHP = 1f;
    public GameObject monster;
    public ParticleSystem hit_effect;

    private void Start()
    {
        hit_effect.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Sword"))
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
        if (hit.CompareTag("Mes"))
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 5f * player_.player_info_attack;
            }
        }
        if (hit.CompareTag("saw"))
        {
            if (CharacterSwordBrandish.isAttacking)
            {
                hit_effect.Play();
                monsterHP -= 5f * player_.player_info_attack;
            }
        }
    }
    private void CheckDeath()
    {
        if (monsterHP <= 0.0f) // 몬스터 체력이 0작거나 같을때
        {
            Destroy(monster.gameObject);

        }
    }
}
