using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase3Attack : MonoBehaviour {
    public float attackTimer;
    public GameObject Acid;
    public Animator acidAnim;
    public float delay = 2.0f;
    public bool onceTried = false;
    public float timer = 0.0f;

    // Use this for initialization
    void Start()
    {
     
        acidAnim = GetComponent<Animator>();
        //Destroy(Acid, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);


    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 0.5f)
        {

        }

        if (attackTimer >= 2.0f)
        {
           
            //Anim.SetBool("isAttacking", true);

        }
        if (attackTimer >= 3.0f)
        {
            Acid.SetActive(true);

           acidAnim.SetBool("Acid", true);
         
            //Anim.SetBool("isAttacking", false);

            onceTried = true;
            attackTimer = 0.0f;
        }
        if (onceTried)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                acidAnim.SetBool("Acid", false);
                Acid.SetActive(false);
                onceTried = false;
                timer = 0.0f;
            }
        }

    }
}
