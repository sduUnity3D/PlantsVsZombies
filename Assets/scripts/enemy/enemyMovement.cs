using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	//向x的负方向移动

	Rigidbody2D rb ;
	public float speed=5f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * -1 * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
