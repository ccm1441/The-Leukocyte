using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : MonoBehaviour {
    public GameObject Questview;
    public Text QuestText;
    //public Text QuestText;
    private bool open = false;

	// Use this for initialization
	void Start () {
        Questview.gameObject.SetActive(false);

	}
	
    public void ExitQuest()
    {
        Questview.gameObject.SetActive(false);
    }

	// Update is called once per frame
	public void Update () {
		if(Input.GetButtonDown("Quest") && !open)
        {
            Questview.gameObject.SetActive(true);
            open = true;
        }
        else if (Input.GetButtonDown("Quest") && open)
        {
            Questview.gameObject.SetActive(false);
            open = false;
        }
        //                    //
        //  첫번째 퀘스트 창  //
        //                    //
        if(Quest.questplaying[0] == true)
        {
            QuestText.text = "QUICK TURN OFF\n\n" + Quest.monsterDie +" / 10";  //퀘스트가 진행중일시 진행창
            if(Quest.isclear[0] == true)
            {
                QuestText.text = "QUICK TURN OFF\n CLEAR\n\nGO TO THE TOWN MAYOR";   //퀘스트의 조건을 모두 완료할 시 
            }
        }
        /*퀘스트 완료시 텍스트창을 지워준다.*/
        if(Quest.iscomplete[0] == true)
        {
            QuestText.text = " "; 
        }
        //                    //
        //  두번째 퀘스트 창  //
        //                    //
        if (Quest.questplaying[1] == true)
        {
            QuestText.text = "RESCUE THE BRAIN" + "\n\n" + "KILL THE NIPHAVIRUS" + "\n" + "0 / 1";
            if(Quest.isclear[1] == true)
            {
                QuestText.text = "RESCUE THE BRAIN\n CLEAR\n\nGO TO THE TOWN MAYOR";
            }
        }
        if(Quest.iscomplete[1] == true)
        {
            QuestText.text = " "; 
        }
        //                    //
        //  세번째 퀘스트 창  //
        //                    //
        if (Quest.questplaying[2] == true)
        {
            QuestText.text = "DESTROY THE LUNGS\n\n" + "KILL THE MERS" + "\n" + "0 / 1";
            if (Quest.isclear[2] == true)
            {
                QuestText.text = "DESTROY THE LUNGS\n CLEAR\n\nGO TO THE TOWN MAYOR";
            }
        }
        if(Quest.iscomplete[2] == true)
        {
            QuestText.text = " ";
        }
        //                    //
        //  네번째 퀘스트 창  //
        //                    //
        if (Quest.questplaying[3] == true)
        {
            QuestText.text = "MORE FASTER ARTERY EXPRESS";
            if(Quest.isclear[3] == true)
            {
                QuestText.text = "MORE FASTER ARTERY EXPRESS\n CLEAR\n\n YOU CAN USE ARTERY EXPRESS";
            }
        }
        if(Quest.iscomplete[3] == true)
        {
            QuestText.text = " ";
        }
        //                      //
        //  다섯번째 퀘스트 창  //
        //                      //
        if (Quest.questplaying[4] == true)
        {
            QuestText.text = "BECAUSE OF THE LIVER\n\nKILL THE ANTHRACIS\n 0 / 1";
            if (Quest.isclear[4] == true)
            {
                QuestText.text = "BECAUSE OF THE LIVER\n CLEAR\n\nGO TO THE TOWN MAYOR";
            }
        }
        if(Quest.iscomplete[4] == true)
        {
            QuestText.text = " ";
        }
        //                      //
        //  여섯번째 퀘스트 창  //
        //                      //
        if (Quest.questplaying[5] == true)
        {
            QuestText.text = "WHAT IS THE COMBINE\n\n HEAR THE DESCRIPTION\nOF THE COMBINATION SYSTEM";
            if (Quest.isclear[5] == true)
            {
                QuestText.text = "WHAT IS THE COMBINE\n CLEAR\n\n YOU CAN UES COMBINATION SYSTEM";
            }
        }
        if(Quest.iscomplete[5] == true)
        {
            QuestText.text = " ";
        }
        //                      //
        //  일곱번째 퀘스트 창  //
        //                      //
        if (Quest.questplaying[6] == true)
        {
            QuestText.text = "SPECIAL MISSION\n OF THE MAYOR\n\n KILL THE \nSUPERBACTERIA\n 0 / 1";
            if (Quest.isclear[6] == true)
            {
                QuestText.text = "SPECIAL MISSION\n OF THE MAYOR\n\n KILL THE \n SUPERBACTERIA \n 1 / 1\n\nGO TO THE \nCAPILLARY TOWN MAYOR";
            }
        }
        if(Quest.iscomplete[6] == true)
        {
            QuestText.text = " ";
        }
        //                      //
        //  여덟번째 퀘스트 창  //
        //                      //
        if (Quest.questplaying[7] == true)
        {
            QuestText.text = "GO SEE THE STUFF";
            if (Quest.isclear[7] == true)
            {
                QuestText.text = "GO SEE THE STUFF\n\n YOU CAN USE\nTHE BLACK MARKET";
            }
        }
        if(Quest.iscomplete[7] == true)
        {
            QuestText.text = " ";
        }
        //                      //
        //  아홉번째 퀘스트 창  //
        //                      //
        if (Quest.questplaying[8] == true)
        {
            QuestText.text = "LEGENDARY WEAPON\n\nINTERACT WITH THE\nLYMP TREE\n 0 / 1";
            if (Quest.isclear[8] == true)
            {
                QuestText.text = "LEGENDARY WEAPON\n\nINTERACT WITH THE\nLYMP TREE\n 1 / 1\n\n\n GO TO THE TOWN";
            }
        }
        if (Quest.questplaying[9] == true)
        {
            QuestText.text = "CAUSE OF DISEAGE\n\nKILL THE \nLAST BOSS EBOLA!!";
            if (Quest.isclear[9] == true)
            {
                QuestText.text = "CAUSE OF DISEAGE";
            }
        }

    }

      
}
