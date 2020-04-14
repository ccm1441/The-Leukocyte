using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge : MonoBehaviour {
    public Image siren;
    public Image dialogueWindow;
    public Text textSpace;
    public Text textDisplay;
    public Text title;
    public Text dialogut_title;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private float textdelaytime = 0.0f; //텍스트 지연호출을 위한 변수 선언

    void Start()
    {
        siren.gameObject.SetActive(false);
        textSpace.gameObject.SetActive(false);
        dialogueWindow.gameObject.SetActive(false);
        textDisplay.gameObject.SetActive(false); //시작시 텍스트를 정지
        StartCoroutine(Type());
        // 코루틴 시작
    }
    void Update()
    {
        if (PlayerMove.isFirst)
        {
            textdelaytime += Time.deltaTime; //시간값을 변수에 대입
            if (textdelaytime >= 2.0f)
            {
                siren.gameObject.SetActive(true);
            }
            if (textdelaytime >= 4.0f && textdelaytime <=5) //시간이 4초경과후 텍스트 실행
            {
                dialogut_title.text = player_.player_info_nick;
                textSpace.gameObject.SetActive(true);
                dialogueWindow.gameObject.SetActive(true);
                textDisplay.gameObject.SetActive(true);
            }
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
            textDisplay.text = ""; // 대화가 끝났을때 텍스트 리셋
            dialogueWindow.gameObject.SetActive(false);
            title.gameObject.SetActive(false);
           // continueButton.SetActive(false); // 대화가 끝났을때 버튼 숨기기
        }
    }
}
