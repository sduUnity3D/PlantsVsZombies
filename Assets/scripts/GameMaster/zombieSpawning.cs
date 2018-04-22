using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawning : MonoBehaviour {


	public static int EnemiesAlive = 0;

	public Wave[] waves; //生成的波次，每波定义类型。以及每波中敌人的生成频率。

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	public float countdown = 2f;

	void Start()
	{
		EnemiesAlive = 0;
		waveIndex = 0;
	}



	public  int waveIndex = 0;

	void Update ()
	{
		//当前屏幕中有敌人的话则直接返回。
		if (EnemiesAlive > 0)
		{
			return;
		}
		//全部波数结束。
		if (waveIndex == waves.Length)
		{
			
			this.enabled = false;
		}

		//倒计时结束，开始生成僵尸。
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);


	}

	IEnumerator SpawnWave ()
	{
		

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.zombie);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		//随机选择一个位置。
		int spawnPosiIndex = Random.Range(0,spawnPoints.Length);
		Instantiate(enemy, spawnPoints[spawnPosiIndex].position,spawnPoints[spawnPosiIndex].rotation);
	}
}
