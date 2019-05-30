using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int currentGold;
	public Text goldText;
	public Player thePlayer;
	private Vector3 playerStartPoint;
	private int goldToAdd;
	public DeathMenu theDeathScreen;
	// Use this for initialization
	void Start () {
		currentGold = 0;
		playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void addGold( int goldToAdd){
		currentGold+= goldToAdd;
		goldText.text = "Gold: " + currentGold + "!";
	}
	public void RestartGame()
	{
		//StartCoroutine ("RestartGameCo");
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);
	}
	public void Reset(){
		theDeathScreen.gameObject.SetActive (false);
		thePlayer.transform.position = playerStartPoint;
		thePlayer.gameObject.SetActive (true);
		currentGold = 0;
		addGold (0);
	
	
	
	}
	/*public IEnumerator RestartGameCo(){
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (1f);
		thePlayer.transform.position = playerStartPoint;
		thePlayer.gameObject.SetActive (true);
		currentGold = 0;
		addGold (0);
	}*/
}
