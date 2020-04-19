using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showtext : MonoBehaviour {

    static float time = 0;
    public Text black;
    public GameObject black_explan_t;

    // Use this for initialization
    void Start () {
        time = 0;
        black.gameObject.SetActive(false);
        black_explan_t.gameObject.SetActive(false);  
        black.text = "단 한 번만\n 이용할 수 있으니 \n잘 생각하게...";
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (time > 0.8)
            black.gameObject.SetActive(true);

        if(market_.black_buy)
            black.text = "그대는 이미 \n 내 물건을 구매했네...";
    }
}
