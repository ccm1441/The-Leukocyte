using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class skip_credit : MonoBehaviour {
    float timer = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //                                 //
        // 크레딧 도중 ESC키를 눌렀을 경우 //
        //    오프닝씬으로 전환            //
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Opening");
        }

        //                                           //
        // 모든 애니메이션이 끝났을 경우 오프닝 전환 //
        //                                           //
         if (timer >= 24.5f)
        {
            SceneManager.LoadScene("Opening");
        }
	}
}
