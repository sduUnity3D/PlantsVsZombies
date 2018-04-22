using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu"; //当玩家选择Menu按钮时要加载到的场景。



	public void Retry ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Menu ()
	{
		SceneManager.LoadScene (menuSceneName);
	}
}
