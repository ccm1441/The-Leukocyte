using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MersFireInducement : MonoBehaviour
{
    public int x = 0;
    public Animator anim;
    public GameObject bossObject;
    Vector2 bulletPos;

    public Transform boss;
    public Transform player;

    public GameObject bullet;
    
    public float bulletTimer = 0.0f;
    public float bulletTimer2 = 0.0f;

    public float bulletTimer3 = 0.0f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //bulletPos = Vector2.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        bulletTimer += Time.deltaTime;
        bulletTimer3 += Time.deltaTime;
        if (x >= 1)
        {
            if (bulletTimer3 >= 0.9f && bulletTimer3 < 1.9f)
            {
                anim.SetBool("isAttacking", true);

            }
        }
        else
        {
            if (bulletTimer3 >= 0.5f && bulletTimer3 < 1.5f)
                anim.SetBool("isAttacking", true);
        }

        if (x == 0)
        {
            if (bulletTimer3 >= 1f)
            {
                anim.SetBool("isAttacking", false);
                bulletTimer3 = 0.0f;
                x++;
            }
        }
        else
        {
            if (bulletTimer3 >= 1.9f)
            {
                anim.SetBool("isAttacking", false);
                bulletTimer3 = 0.0f;
            }
        }
        if (bulletTimer >= 1.0f)
        {
            bulletTimer2 += Time.deltaTime;
          
        
            if (bulletTimer2 >= 0.2f)
            {
               
                Fire();
                bulletTimer2 = 0.0f;
            }
            if (bulletTimer >= 2.0f)
            {
             
                bulletTimer = 0.0f;
            }
        }
       

    }

    void Fire()
    {
     
        //bulletPos = transform.position;
        bulletPos = transform.position;
        Instantiate(bullet, transform.position, Quaternion.identity);

 
        
    }
}
