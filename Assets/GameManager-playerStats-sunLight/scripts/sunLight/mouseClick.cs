using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour {
	sunLightMovement movememntScript;
	public Vector3 targetPosition;
	public float speed  = 1f;
	Rigidbody2D rb;

	void Update()
	{
		
	}
	void Start()
	{
		movememntScript = GetComponent<sunLightMovement> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	void OnMouseDown()
	{
		playerStats.LightCount += 25;
		movememntScript.enabled = false;
		moveToDest ();
	}

	void moveToDest()
	{
		//旋转
		rb.angularVelocity = 300;

		Vector2 dir = targetPosition-transform.position;
		rb.velocity = dir * speed;
	}
}
