using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGameOver : MonoBehaviour {

	public GameManager gameManager;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "enemy") {
			Debug.Log ("gameover");
			gameManager.EndGame ();
		}

	}

}
