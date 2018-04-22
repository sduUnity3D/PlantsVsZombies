using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//对游戏的开始和结束进行控制。
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	public GameObject disableWhenOver;
	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (playerStats.lives <= 0)
		{
			EndGame();
		}
	}

	public void EndGame ()
	{
		GameIsOver = true;
		disableWhenOver.SetActive (false);
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
