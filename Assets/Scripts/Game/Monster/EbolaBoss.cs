using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbolaBoss : MonoBehaviour {
    public Animator ebola;
    public Sprite phase2;
    public Sprite phase3;
    public Sprite phase4;
    public ParticleSystem hit_effect;

    void Start()
    {
        hit_effect.Pause();
        ebola = GetComponent<Animator>();
    }
	void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Sword"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.05f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.05f;
            }
            else  if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.05f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.05f;
            }
        }
        if (hit.CompareTag("InjectionBullet"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.07f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.07f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.07f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.07f;
            }
        }
        if (hit.CompareTag("tamiflu"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.1f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.1f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.1f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.1f;
            }
        }
        if (hit.CompareTag("penicillin"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.12f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.12f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.12f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.12f;
            }
        }
        if (hit.CompareTag("tablet"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.13f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.13f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.13f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.13f;
            }
        }
        if (hit.CompareTag("tablet2"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.14f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.14f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.14f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.14f;
            }
        }
        if (hit.CompareTag("tablet3"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.15f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.15f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.15f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.15f;
            }
        }
        if (hit.CompareTag("scissors"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.16f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.16f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.16f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.16f;
            }
        }
        if (hit.CompareTag("Mes"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.17f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.17f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.17f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.17f;
            }
        }
        if (hit.CompareTag("saw"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.18f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.18f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.18f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.18f;
            }
        }
        if (hit.CompareTag("legendweapon"))
        {
            if (EbolaBossHealthbar.Phase1)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth1 -= 0.2f;
            }
            if (EbolaBossHealthbar.Phase2)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth2 -= 0.2f;
            }
            else if (EbolaBossHealthbar.Phase3)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth3 -= 0.2f;
            }
            else if (EbolaBossHealthbar.Phase4)
            {
                hit_effect.Play();
                EbolaBossHealthbar.bossHealth4 -= 0.2f;
            }
        }
    }

    void Update()
    {
        if(EbolaBossHealthbar.Phase2)
        {
            this.GetComponent<SpriteRenderer>().sprite = phase2;
            ebola.SetBool("Phase1_Dead", true);
        }

        else if (EbolaBossHealthbar.Phase3)
        {
            this.GetComponent<SpriteRenderer>().sprite = phase3;
            ebola.SetBool("Phase2_Dead", true);
        }
        else if (EbolaBossHealthbar.Phase4)
        {
            this.GetComponent<SpriteRenderer>().sprite = phase4;
            ebola.SetBool("Phase3_Dead", true);
        }
    }
}
