using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public string mainMenuLevel;
	public SettingsMenu settings;
	private Rigidbody rb;
	[SerializeField]
	private float speed;
	private Animator anim;
	float lengthinZaxis=7.6f;
	Vector3 lastPosition;
	Vector3 lastPosition1;
	Vector3 lastPosition2;
	[SerializeField]
	GameObject platform;
	[SerializeField]
	GameObject gold;
	[SerializeField]
	GameObject Obstacle;
	[SerializeField]
	Transform firstObject;
	[SerializeField]
	Transform firstGold;
	[SerializeField]
	Transform firstObstacle;
	[SerializeField]

	int score=0;
	[SerializeField]
	Text scoreUI;
	float _score =0;
	public AudioSource JumpSound;
	public AudioSource DieSound;
	private bool isgrounded=true;
	private bool doubleJump;
	public GameManager theGameManager;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = this.GetComponent<Rigidbody> ();
		speed = 6;
		rb.velocity = new Vector3 (0f, 0f, speed);
		lastPosition = firstObject.transform.position;
		lastPosition1 = firstGold.transform.position;
		lastPosition2 = firstObstacle.transform.position;
		InvokeRepeating ("spawning", 0f, 0.03f);
		score=0;
		_score = 0f;
	}




	private void spawning(){ 
		GameObject _object = Instantiate (platform)as GameObject;
		GameObject _object1 = Instantiate (gold)as GameObject;
		GameObject _object2 = Instantiate (Obstacle)as GameObject;
		int _random = Random.Range (0, 7);
		if (_random <= 3) {
			
			_object.transform.position = lastPosition + new Vector3 (0f, 0f, lengthinZaxis);
			_object1.transform.position = lastPosition1 + new Vector3 (0f, 0f, 7f);
			_object2.transform.position = lastPosition2 + new Vector3 (0f, 0f, 15f);
		} else {
			_object.transform.position = lastPosition + new Vector3 (0f, 0f, 9f);
			_object1.transform.position = lastPosition1 + new Vector3 (0f, 0f, 12f);
			_object2.transform.position = lastPosition2 + new Vector3 (0f, 0f, 20f);
		}
		lastPosition = _object.transform.position;
		lastPosition1 = _object1.transform.position;
		lastPosition2 = _object2.transform.position; 



	}



	private void scoreUpdate(){
		_score += 5f * Time.deltaTime;
		score=Mathf.RoundToInt(_score);

		scoreUI.text = score.ToString ();
	
	}
	// Update is called once per frame
	void Update ()
	{ if (score > 30 && score < 90)
			hard ();
		else if (score > 90 && score < 130)
			hard ();
		else if (score > 130)
			hard ();
	
		if (isgrounded == true) {
			doubleJump = false;
		}
			if ((Input.GetKeyDown ("space") || Input.GetKeyDown (KeyCode.JoystickButton0)) && isgrounded) {
				rb.AddForce (0f, 4.8f, 0f, ForceMode.Impulse);	
				anim.Play ("Jumping");
				JumpSound.Play ();
				//JumpSound.Play ();
			}
			if ((Input.GetKeyDown ("space") || Input.GetKeyDown (KeyCode.JoystickButton0)) && !isgrounded && !doubleJump) {
				rb.AddForce (0f, 3f, 0f, ForceMode.Impulse);
				anim.Play ("Jumping");
				JumpSound.Play ();
				doubleJump = true;
			}
			
		scoreUpdate ();
		if (Input.GetKeyDown(KeyCode.Q))
			SceneManager.LoadScene(mainMenuLevel);

	}
	void OnCollisionEnter( Collision theCollision){
		if(theCollision.gameObject.name == "Ground")
		{
			isgrounded = true;
		}
	}
	void hard(){
		rb.AddForce(0f,0f,0.09f,ForceMode.Acceleration);
	}

	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit( Collision theCollision){
		if(theCollision.gameObject.name == "Ground")
		{
			isgrounded = false;
		}
	}




	void OnTriggerEnter(Collider col){
		if ((col.gameObject.tag == "Water")||(col.gameObject.tag=="Obs")) {
			gameOver ();}
	}
	
	private void gameOver(){
		Debug.Log ("Game Over");
		DieSound.Play ();
		theGameManager.RestartGame ();
		Start ();


	}
}
