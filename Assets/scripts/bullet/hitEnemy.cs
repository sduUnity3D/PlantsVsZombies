﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour {

	public float damage;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "enemy") {
			other.gameObject.GetComponent<enemyHealth> ().be_damage (damage);
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
