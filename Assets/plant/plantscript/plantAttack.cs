using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAttack : MonoBehaviour {
	private bool onAttack;
	public LayerMask zombielayer;
	public float attackspeed;
	public float attackdistance;
	private float attackcooldown;
	public int planttype;
	private float times;
	// Use this for initialization
	void Start () {
		
		onAttack = false;

	}

	// Update is called once per frame
	void Update () {
		times = Time.time;
		//ray check 
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right,10f,zombielayer);
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
		GameObject hp_bar = (GameObject)Resources.Load("zidan");  
		Instantiate(hp_bar);  
		hp_bar.transform.position = gameObject.transform.position;
		hp_bar.GetComponent<Rigidbody2D>().velocity = new Vector2 (5f, 0f);
		hp_bar.GetComponent<zidanscript> ().shootdistance = 20f;
		hp_bar.GetComponent<zidanscript> ().speed = 5;
	}

}
