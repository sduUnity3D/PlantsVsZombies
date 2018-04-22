using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunLightSpawning : MonoBehaviour {

	//生成阳光。
	public GameObject sunLight;
	public Vector3 spawn; //生成的地点。

	public float startWait;

	public float waveWait;



	private void Start()
	{
		

		StartCoroutine( spawnWaves());        
	}

	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			
			Vector3 spawnPosition = new Vector3(Random.Range(-spawn.x, spawn.x), spawn.y, spawn.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(sunLight, spawnPosition, spawnRotation);


			yield return new WaitForSeconds(waveWait);


		}


	}




}
