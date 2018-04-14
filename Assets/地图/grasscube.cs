using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class grasscube : MonoBehaviour {
	public bool haveplant;
	public GameObject plants;
	private int i;
	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OnClick);
		haveplant = false;
		i = 0;
	}

	private void OnClick(){
		//check gamemaster if(gamemaster.plant=xxx)addplant();
		//check gamemaster if(gamemaster.chanzi==xxx)removeplant();
	
		//Debug.Log ("Button Clicked. ClickHandler.");
	}

	// Update is called once per frame
	void Update () {
		
	}
	void addplant(){
		haveplant = true;

		GameObject hp_bar = (GameObject)Resources.Load("plant/plant");  
		hp_bar=Instantiate(hp_bar);  
		hp_bar.transform.position = gameObject.transform.position;
		hp_bar.GetComponent<plantHealth> ().grass = gameObject;
		hp_bar.transform.parent = GetComponent<RectTransform> ();
		//Debug.Log (plants.GetComponent<plantHealth> ().health);
		plants = hp_bar;
	}
	void removeplant(){
		
		plants.GetComponent<plantHealth> ().be_damage (9999f);
	}

}
