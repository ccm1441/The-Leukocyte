﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderVolume : MonoBehaviour {

    public Slider slider;

    public static float sliderVolume;
    // Use this for initialization
    void Start () {
      
	
	}   
	
	// Update is called once per frame
	void Update () {
        sliderVolume = slider.value;
    }
}
