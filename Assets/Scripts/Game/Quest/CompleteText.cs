using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteText : MonoBehaviour {

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
            if (Quest.viewing[0] == true)
            {
                time += Time.deltaTime;
                complete.gameObject.SetActive(true);
                complete.text = "THANK YOU!!";
                board.gameObject.SetActive(true);
                if(time >= 2.5f)
                {
                    complete.text = "EXP : 40\n HEMO : 300";
                }
                if (time >= 5.0f)
                {
                    complete.gameObject.SetActive(false);
                    board.gameObject.SetActive(false);
      
                }
            }
            if(Quest.viewing[1] == true)
            {
                time += Time.deltaTime;
                complete.gameObject.SetActive(true);
                complete.text = "THANK YOU!!";
                board.gameObject.SetActive(true);
                if (time >= 2.5f)
                {
                    complete.text = "EXP : 50\n HEMO : 400";
                }
                if (time >= 5.0f)
                {
                    complete.gameObject.SetActive(false);
                    board.gameObject.SetActive(false);
                 
                }
            }
            if (Quest.viewing[2] == true)
            {
                time += Time.deltaTime;
                complete.gameObject.SetActive(true);
                complete.text = "THANK YOU!!";
                board.gameObject.SetActive(true);
                if (time >= 2.5f)
                {
                    complete.text = "EXP : 50\n HEMO : 400";
                }
                if (time >= 5.0f)
                {
                    complete.gameObject.SetActive(false);
                    board.gameObject.SetActive(false);
                  
                }
            }
        if (Quest.viewing[4] == true)
        {
            time += Time.deltaTime;
            complete.gameObject.SetActive(true);
            complete.text = "THANK YOU!!";
            board.gameObject.SetActive(true);
            if (time >= 2.5f)
            {
                complete.text = "EXP : 60\n HEMO : 400";
            }
            if (time >= 5.0f)
            {
                complete.gameObject.SetActive(false);
                board.gameObject.SetActive(false);
            
            
            }
        }
        if (Quest.viewing[6] == true)
            {
            time += Time.deltaTime;
            complete.gameObject.SetActive(true);
            complete.text = "THANK YOU!!";
            board.gameObject.SetActive(true);
            if (time >= 2.5f)
            {
                complete.text = "EXP : 50\n HEMO : 400";
            }
            if (time >= 5.0f)
            {
                complete.gameObject.SetActive(false);
                board.gameObject.SetActive(false);
            
            }
          }

    }
}
