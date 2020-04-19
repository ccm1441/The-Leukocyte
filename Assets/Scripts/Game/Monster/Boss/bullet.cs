using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float velX = 5f;
    public float velY = 5f;
    public float timer = 0f;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        rb.velocity = new Vector3(velX, velY,timer);
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.CompareTag("PlayerBody"))
        {
            Destroy(gameObject);
            player_.player_info_hp -= 10;
        }
    }
}
