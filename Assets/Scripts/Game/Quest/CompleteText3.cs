using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteText3 : MonoBehaviour {

    static float time = 0;
    public Text complete;
    public GameObject board;

    // Use this for initialization
    void Start () {
        time = 0;
        complete.gameObject.SetActive(false);
        board.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Quest.viewing[7] == true)
        {
            time += Time.deltaTime;
            complete.gameObject.SetActive(true);
            complete.text = "EXP : 50\n HEMO : 300";
            board.gameObject.SetActive(true);
            if(time >= 3.0f)
            {
                complete.text = "PRESS\nSPACE BAR..";
            }
            if (time >= 6.0f)
            {
                complete.gameObject.SetActive(false);
                board.gameObject.SetActive(false);
            }

        }
    }
}
