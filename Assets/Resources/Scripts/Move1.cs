﻿using UnityEngine;
using System.Collections;

public class Move1 : MonoBehaviour {

	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0, (Input.GetAxis("Vertical") * speed * Time.deltaTime));
	}
}
