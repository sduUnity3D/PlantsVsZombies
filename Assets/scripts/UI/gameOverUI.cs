using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverUI : MonoBehaviour {

	public void quit()
	{
		Application.Quit ();
	}

	public void reStart()
	{
		SceneManager.LoadScene ("gamePlay");
	}
	public void menu()
	{
		SceneManager.LoadScene ("StartScene");
	}
}
