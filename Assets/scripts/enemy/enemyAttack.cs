using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {


	public LayerMask plantMask;
	enemyMovement enemyMovementScript;
	bool onAttack=  false;
	GameObject target;
	public float damage ;
	float attackcooldown;
	public float attackspeed= .5f;
	public float nextTimeToAttack= 0f;
	public float attackdistance = 2f;
	float preSpeed;
	// Use this for initialization
	Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		enemyMovementScript = GetComponent<enemyMovement> ();
		preSpeed = enemyMovementScript.speed;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, -transform.right,attackdistance,plantMask);
		Debug.DrawLine(transform.position,transform.position-new Vector3(attackdistance,0f,0f),Color.blue);
		if (hit.collider != null&&onAttack==false) {
			target = hit.collider.gameObject;
			rb.velocity = Vector2.zero;
			attack ();
			onAttack = true;
			attackcooldown = Time.time+1/attackspeed;
		} else if(hit.collider==null){
			
			onAttack = false;
		}


		if (onAttack == true) {
			if (attackcooldown < Time.time) {
				attackcooldown = Time.time+1/attackspeed;
				attack ();
			}
		}
		if (target == null) {
			rb.velocity = transform.right * -1 * preSpeed;
		}
	}

	void OnTriggetEnter2D(Collider2D other)
	{
		if (other.tag == "plant") {
			enemyMovementScript.enabled = false;//停止移动
			target = other.gameObject;
		}
	}

	void attack()
	{
		plantHealth pHealthScript = target.GetComponent<plantHealth> ();
		pHealthScript.be_damage (damage);

	}

}
