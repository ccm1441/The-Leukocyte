using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InducementBullet : MonoBehaviour {
    public Transform target;
    public float speed = 1f;
    public float timer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
        timer += Time.deltaTime;
        if(timer>=3.0f)
        {
            Destroy(gameObject);
            timer = 0.0f;
        }
       
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PlayerBody"))
        {
            Destroy(gameObject);
            player_.player_info_hp -= 10;
        }
    }
}
