using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMove : MonoBehaviour {

    private Animator Setting;

	// Use this for initialization
	void Start () {
        Setting = GetComponent<Animator>();
	}

    public void SetMove()
    {
        Setting.SetBool("isHidden", true); //setting버튼 클릭시 애니메이션 실행
    }
    public void SetDefalut()
    {
        Setting.SetBool("isHidden", false); //setting의 뒤로가기 버튼 클릭시 애니메이션 실행
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
