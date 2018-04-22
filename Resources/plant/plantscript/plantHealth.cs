using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantHealth : MonoBehaviour {
	public float health;
	public GameObject grass;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void be_damage(float hurt){
		health -= hurt;
		if (health <= 0) {
			//grass.GetComponent<grasscube> ().haveplant = false;
			Destroy (gameObject);
		}
	}

}
