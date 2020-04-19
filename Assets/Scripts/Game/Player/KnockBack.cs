using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

    public GameObject player;
    static bool godmode = false;

    IEnumerator god()
    { 
        yield return new WaitForSeconds(2);
        godmode = false;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag=="Spike")
        {
            player_.player_info_hp -= 10;
        }
        if (hit.gameObject.tag == "AcidHitBox")
        {
            player_.player_info_hp -= 5;
        }
            if (hit.gameObject.tag == "MonsterHitBox")
        {
           
            if (hit.transform.position.x <transform.position.x && !godmode)
            {              
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800, 0f));
                player_.player_info_hp -= 10;
                godmode = true;
                StartCoroutine("god");
            }
            else if (hit.transform.position.x >transform.position.x && !godmode)
            {
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800, 0f));
                player_.player_info_hp -= 10;
               godmode = true;
                StartCoroutine("god");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "AcidHitBox")
        {
            player_.player_info_hp -= 3;
        }
        if (hit.gameObject.tag == "MonsterHitBox")
        {
            if (hit.transform.position.x <transform.position.x && !godmode)
            {
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800, 0f));
                player_.player_info_hp -= 10;
                godmode = true;
                StartCoroutine("god");
            }
            else if (hit.transform.position.x >transform.position.x &&!godmode)
            {
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800, 0f));
                player_.player_info_hp -= 10;
                godmode = true;
                StartCoroutine("god");
            }
        }
    }
}
