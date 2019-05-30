using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {
	public Slider volume;
	public AudioSource music;
	public Dropdown configx;
	public GameObject Settings;
	void Start(){

	}
	void Update(){
		music.volume = volume.value;
	
	}

	public void quit(){
		Settings.SetActive (false);
	}
	public bool Config(){
		
		if (configx.value == 0)
			return true;
		else
			return false;
	}
}
