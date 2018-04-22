using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

	public float health;
	SpriteRenderer sp;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();

	}

	// Update is called once per frame
	void Update () {
		 
	}
	public void be_damage(float hurt){
		//变成红色受到攻击时

		health -= hurt;
		sp.color = Color.red;
		if (health <= 0) {
			//grass.GetComponent<grasscube> ().haveplant = false;

			zombieSpawning.EnemiesAlive--;
			Destroy (gameObject);
		}
		//sp.color = Color.white;
	}
}
