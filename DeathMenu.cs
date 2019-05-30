using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour {
	public string playGameLevel;
	public string mainMenuLevel;
	public void RestartGame(){
		SceneManager.LoadScene (playGameLevel);
		//FindObjectOfType<GameManager> ().Reset ();
	}
	public void QuitToMain(){
	
		SceneManager.LoadScene(mainMenuLevel);
	
	}
}
