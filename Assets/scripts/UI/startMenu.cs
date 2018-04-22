using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startMenu : MonoBehaviour {
	public string playScene;
	public void startGame()
	{
		Debug.Log ("pressed");
		SceneManager.LoadScene (playScene);
	}

	public void quitGame()
	{
		Application.Quit ();
	}
}
