﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDestruction : MonoBehaviour {
	public GameObject goldDestructionPoint;
	// Use this for initialization
	void Start () {
		goldDestructionPoint = GameObject.Find ("GoldDestructionPoint");

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.z < goldDestructionPoint.transform.position.z-7) {

			Destroy (gameObject);

		}
	}
}
