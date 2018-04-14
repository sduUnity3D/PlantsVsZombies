using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

	//定义玩家的一些属性
	public static int LightCount;
	public int StartLightCount = 50;
	public static int lives;
	public int StartLives = 5;
	// Use this for initialization
	void Start () {
		LightCount = StartLightCount;
		lives = StartLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
