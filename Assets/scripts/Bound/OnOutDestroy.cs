using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOutDestroy : MonoBehaviour {

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "enemy") {
			zombieSpawning.EnemiesAlive--;
		}
		Destroy(other.gameObject);
	}
}
