using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteText2 : MonoBehaviour {

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
        if (Quest.viewing[5] == true)
        {
            time += Time.deltaTime;
            complete.gameObject.SetActive(true);
            complete.text = "YOU CAN USE\nCOMBINE!!";
            board.gameObject.SetActive(true);
            if (time >= 6.0f)
            {
                complete.gameObject.SetActive(false);
                board.gameObject.SetActive(false);
                Quest.viewing[5] = false;
            }

        }
    }
}
