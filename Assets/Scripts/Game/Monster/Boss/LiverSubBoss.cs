using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiverSubBoss : MonoBehaviour
{
    public bool pattern1 = false;
    public Animator anim;
    public float fasterTimer;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        fasterTimer += Time.deltaTime;

        if (fasterTimer >= 3.0f)
        {
            pattern1 = true;

        }

        if (pattern1)
        {
            anim.SetBool("isFast", true);
            BossMovement.movePower += 0.05f;

            if (fasterTimer >= 5.0f)
            {
                fasterTimer = 0.0f;
                BossMovement.movePower = 1.0f;
                anim.SetBool("isFast", false);
                pattern1 = !pattern1;

            }
        }
    }



}
/*
public float velX = 5f;
float velY = 0f;
public GameObject rb;

void Start()
{
    //rb = GetComponent<Rigidbody2D>();
}
void Update()
{
    rb.velocity = new Vector2(velX, velY);
    Instantiate(rb, transform.position, Quaternion.identity);
}
*/


//public GameObject bullet;
//public float speed = 100f;
/*
public int number;
public float speed;
public GameObject bullet;

private Vector3 startpoint;
private const float radius = 1f;
*/

// Update is called once per frame
//void Update() {
/*
GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
Rigidbody2D instBulletRigidBody = instBullet.GetComponent<Rigidbody2D>();
instBulletRigidBody.AddForce(Vector3.forward * speed);
*/
/*
startpoint = transform.position;
Spawn(number);
*/

/*
private void Spawn(int _number)
{
    float angleStep = 360f / _number;
    float angle = 0f;

    for(int i=0; i<_number-1;i++)
    {
        float projectXposition = startpoint.x + Mathf.Sin((angle * Mathf.PI )/180) * radius;
        float projectYposition = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;


        Vector3 projecttileVector = new Vector3(projectXposition, projectYposition, 0);
        Vector3 projectMoveDirection = (projecttileVector - startpoint).normalized * speed;

        GameObject tmpObj = Instantiate(bullet, startpoint, Quaternion.identity);
        tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector3(projectMoveDirection.x, 0, projectMoveDirection.y);

        angle += angleStep;
    }*/



