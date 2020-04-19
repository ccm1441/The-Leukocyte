using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Sound : MonoBehaviour {
    AudioSource BgSound;
    public AudioClip sound;
	// Use this for initialization
	void Start () {
        BgSound = gameObject.GetComponent<AudioSource>();
        BgSound.clip = sound;
        BgSound.volume = SliderVolume.sliderVolume;
        BgSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
