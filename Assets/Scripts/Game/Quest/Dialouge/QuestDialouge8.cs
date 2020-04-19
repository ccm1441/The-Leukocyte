using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialouge8 : MonoBehaviour
{
    public Image dialogueWindow;
    public Text textSpace;
    public Text textDisplay;
    public string[] sentences;
    private int index;
    private int endcount;
    public float typingSpeed;
    private float textdelaytime = 0.0f; //텍스트 지연호출을 위한 변수 선언
    void Start()
    {
        textSpace.gameObject.SetActive(false);
        dialogueWindow.gameObject.SetActive(false);
        textDisplay.gameObject.SetActive(false); //시작시 텍스트를 정지
        StartCoroutine(Type());
        // 코루틴 시작
    }
    void Update()
    {
        if (Quest.queststart[8] == true)
        {
            if (Quest.isclear[8] == false)
            {
                //  textdelaytime += Time.deltaTime; //시간값을 변수에 대입
                textSpace.gameObject.SetActive(true);
                dialogueWindow.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
                if (textDisplay.text == sentences[index])
                {
                    textSpace.text = "PRESS SPACEBAR >>";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        textSpace.text = "";
                        NextSentence();
                    }
                }
            }
        }
    }
    void LateUpdate()
    {
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); // 각 글자 딜레이
        }
    }


    public void NextSentence()
    {
        //continueButton.SetActive(false); // 플레이어가 계속 클릭하지 못하도록
        if (index < sentences.Length - 1) // array는 0부터 시작
        {
            index++;
            textDisplay.text = ""; // 텍스트 리셋(문장이 쌓이지 않도록)
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            if (Quest.queststart[8] == true)
            {
                Quest.queststart[8] = false;
                Quest.questplaying[8] = true;
            }
            dialogueWindow.gameObject.SetActive(false);
            // 대화가 끝났을때 텍스트 리셋
            //continueButton.SetActive(false); // 대화가 끝났을때 버튼 숨기기
        }
    }
}
