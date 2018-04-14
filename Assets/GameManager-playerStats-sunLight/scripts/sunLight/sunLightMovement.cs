using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunLightMovement : MonoBehaviour {
	public float speed = 2f;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up * -1 * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
