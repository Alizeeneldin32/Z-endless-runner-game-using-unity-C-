using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public string playGameLevel;
	public GameObject settings;
	public void playGame(){
		SceneManager.LoadScene(playGameLevel);﻿
	}
	public void goSettings(){
		settings.SetActive (true);
	}
	public void QuitGame(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
