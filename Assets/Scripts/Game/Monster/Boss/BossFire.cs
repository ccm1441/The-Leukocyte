using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour {
    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;
    Vector2 bulletPos2;
    Vector3 bulletPos3;
    public Transform boss;
    public Transform player;
    public GameObject bossObject;
    public float bulletTimer = 0.0f;
    public float bulletTimer2 = 0.0f;

    public float bulletTimer3 = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= 1.0f)
        {
            bulletTimer2 += Time.deltaTime;
            bossObject.gameObject.GetComponent<BossMovement>().enabled = false;
            if (bulletTimer2 >= 0.2f)
            {
                Fire();
                bulletTimer2 = 0.0f;
            }
            if(bulletTimer>=2.0f)
            bulletTimer = 0.0f;
        }
        if(bulletTimer > 0.0f&&bulletTimer <1.0f)
        {
            bossObject.gameObject.GetComponent<BossMovement>().enabled = true;
        }
       
    }

    void Fire()
    {
        bulletPos = transform.position;
        if (player.position.x < boss.position.x)
        {
            bulletPos += new Vector2(+1f, -1f);
            bulletPos2.x = bulletPos.x + 0.4f;
            bulletPos2.y = bulletPos.y + 0.4f;
            bulletPos3.x = bulletPos.x + 0.8f;
            bulletPos3.y = bulletPos.y + 0.8f;
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
            Instantiate(bulletToLeft, bulletPos2, Quaternion.identity);
            Instantiate(bulletToLeft, bulletPos3, Quaternion.identity);
        }
        if (player.position.x > boss.position.x)
        {
            bulletPos += new Vector2(-1f, -1f);
            bulletPos2.x = bulletPos.x + 0.4f;
            bulletPos2.y = bulletPos.y + 0.4f;
            bulletPos3.x = bulletPos.x + 0.8f;
            bulletPos3.y = bulletPos.y + 0.8f;
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
            Instantiate(bulletToRight, bulletPos2, Quaternion.identity);
            Instantiate(bulletToRight, bulletPos3, Quaternion.identity);
        }
    }
}
