using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndSceneMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void GoToTitle()
    {
        SceneManager.LoadScene("Opening");
    }

    public void GoToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
