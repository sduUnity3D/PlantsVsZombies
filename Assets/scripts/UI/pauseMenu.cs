using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {


	public GameObject pauseUI;
	public bool isPaused = false;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused) {
				
				resume ();
			} else {
				pause ();
			}
			isPaused = !isPaused;
		}
	}
	public void resume()
	{
		
		pauseUI.SetActive (false);
		Time.timeScale =1;
	}

	public void pause()
	{
		
		pauseUI.SetActive (true);
		Time.timeScale = 0;
	}

	public void Quit()
	{
		Application.Quit ();
	}



}
