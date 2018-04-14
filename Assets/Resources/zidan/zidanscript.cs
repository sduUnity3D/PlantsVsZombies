using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zidanscript : MonoBehaviour {
	Rigidbody2D rx;
	public float shootdistance;
	private Vector3 startpos;
	public float speed;
	// Use this for initialization
	void Start () {
	 rx = GetComponent<Rigidbody2D> ();
		rx.velocity = new Vector2 (speed, 0f);

		//startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (speed);
		//rx.velocity = new Vector2 (speed, 0f);
		if (transform.position.x - startpos.x > shootdistance)
			Destroy (gameObject);
		//transform.position = transform.position + new Vector3 (1f, 0f);
	}
}
