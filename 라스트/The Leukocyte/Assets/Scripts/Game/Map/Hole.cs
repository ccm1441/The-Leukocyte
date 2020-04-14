using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour {

    public GameObject player;
    public GameObject hole;
    private Animator fallani;
    private Animator fallani2;
    private Animator fallani3;

    /* 플레이어가 구멍에 빠질 때 */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //플레이어라는 태그가 구멍에 충돌하면
        {
           // player.SetActive(false); //캐릭터를 없애기

            if (hole.gameObject.tag == "Hole")
            {
                player_.player_info_hp = 0;
                fallani.SetBool("Fall", true);
            }
            else if (hole.gameObject.tag == "Hole2")
            {
                player_.player_info_hp = 0;
                fallani2.SetBool("Fall", true);
            }
            else if (hole.gameObject.tag == "Hole3")
            {
                player_.player_info_hp = 0;
                fallani3.SetBool("Fall", true);
            }
        }
    }

    void Start()
    {
        /* 한 맵에 구멍이 2개이상일시 각 구멍마다의 추락애니메이션을 위해*/
        Scene scene = SceneManager.GetActiveScene();
       
            fallani = GameObject.Find("Fall").GetComponent<Animator>();
        
        if (scene.name == "2-2" || scene.name == "4-1"||scene.name == "4")
        {
            fallani2 = GameObject.Find("Fall2").GetComponent<Animator>();
        }   
        if (scene.name == "4")
        {
            fallani3 = GameObject.Find("Fall3").GetComponent<Animator>();
        }
        
        
    }

    
}
