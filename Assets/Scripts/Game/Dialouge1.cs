using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialouge1 : MonoBehaviour {

    public Image dialogueWindow;
    public Text textSpace;
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private float textdelaytime = 0.0f;
    public static bool end = false;

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Ending2");
    }

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

            textdelaytime += Time.deltaTime;
            if (textdelaytime >= 1.0f) //시간이 4초경과후 텍스트 실행
            {
                textdelaytime += Time.deltaTime;
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
            textDisplay.text = ""; // 대화가 끝났을때 텍스트 리셋
            end = true; //대화가 끝나고 페이드 아웃

            StartCoroutine(NextScene());

            //continueButton.SetActive(false); // 대화가 끝났을때 버튼 숨기기
        }
    }
}
