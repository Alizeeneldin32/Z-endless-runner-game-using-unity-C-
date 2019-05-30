using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleDestruction : MonoBehaviour {
	public GameObject hurdleDestructionPoint;
	// Use this for initialization
	void Start () {
		hurdleDestructionPoint = GameObject.Find ("HurdleDestructionPoint");

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.z < hurdleDestructionPoint.transform.position.z-7) {

			Destroy (gameObject);

		}
	}
}
