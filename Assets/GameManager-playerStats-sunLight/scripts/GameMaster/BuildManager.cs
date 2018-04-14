using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance; //场景中统一电泳

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect; //建立的效果
	public GameObject removeEffect; //移除的效果。

	private GameObject plantToBuild; //准备终止的植物。
	private bool useShovel = false;


	public bool CanBuild { get { return plantToBuild != null; } }
	public bool HasMoney { get { return playerStats.LightCount >= 50f/*应替换成植物的阳光数量*/; } } //直接判断是否有足够的钱。
	public bool CanRemove{get{return useShovel;}}

	public void SelectTurretToBuild (GameObject plant)
	{
		
		plantToBuild = plant;

	}

	public void DeUseShovel()
	{
		useShovel = false;
	}
	public void UseShovel()
	{
		useShovel = true;
		plantToBuild = null;
	}
	public GameObject GetTurretToBuild ()
	{
		return plantToBuild;
	}
}
