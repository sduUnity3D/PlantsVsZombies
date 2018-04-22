using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour {
	BuildManager buildManager;
	public GameObject shovelPic;
	// Use this for initialization
	void Start () {

		buildManager = BuildManager.instance;
	}
	public void clickShovel()
	{
		buildManager.UseShovel ();
		GameObject shovelObj = Instantiate (shovelPic);
		buildManager.dragPic = shovelObj;
	}
}
