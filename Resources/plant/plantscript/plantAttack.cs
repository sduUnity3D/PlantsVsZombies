using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAttack : MonoBehaviour {
	public Vector3 offset = new Vector3(0.3f,0f,0f);
	private bool onAttack;
	public LayerMask zombielayer;
	public float attackspeed;
	public float attackdistance;
	private float attackcooldown;
	public int planttype;
	private float times;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
		onAttack = false;

	}

	// Update is called once per frame
	void Update () {
		times = Time.time;
		//ray check 
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right,attackdistance,zombielayer);
		Debug.DrawLine(transform.position,transform.position+new Vector3(attackdistance,0f,0f),Color.red);
		if (hit.collider != null&&onAttack==false) {
			attack ();
			onAttack = true;
			attackcooldown = Time.time+attackspeed;
		} else if(hit.collider==null){
			onAttack = false;}
		if (onAttack == true) {
			if (attackcooldown < Time.time) {
				attackcooldown = Time.time+attackspeed;
				attack ();
			}
		}

		


	}
	void FixedUpdate(){
	
	
	}

	void attack(){
		
		Instantiate(bullet,transform.position+offset,Quaternion.identity);  

		bullet.GetComponent<Rigidbody2D>().velocity = new Vector2 (5f, 0f);
		bullet.GetComponent<zidanscript> ().shootdistance = 20f;
		bullet.GetComponent<zidanscript> ().speed = 5;
	}

}
