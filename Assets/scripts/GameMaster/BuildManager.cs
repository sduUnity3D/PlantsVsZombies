using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour {

	public GameObject dragPic;


	public static BuildManager instance; //场景中统一 
	 
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

	//private GameObject plantToBuild; //准备种植的植物。
	//先换成public变量测试一下
	private plantBluePrint plantToBuild;
	public bool useShovel = false;


	public bool CanBuild { get { return plantToBuild != null; } }
	public bool HasMoney { get { return playerStats.LightCount >=plantToBuild.cost/*应替换成植物的阳光数量*/; } } //直接判断是否有足够的钱。
	public bool CanRemove{get{return useShovel;}}

	public void SelectTurretToBuild (plantBluePrint  plant)
	{
		
		plantToBuild = plant;

	}

	public void DeUseShovel()
	{
		Destroy (dragPic);
		useShovel = false;

	}
	public void UseShovel()
	{
		useShovel = true;
		DeSelectPlant ();

	}
	public plantBluePrint  GetPlantToBuild ()
	{
		return plantToBuild;
	}
	public void DeSelectPlant()
	{
		plantToBuild = null;
		Destroy (dragPic);
	}
	void Update()
	{
		//Vector3 mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		if (dragPic!=null) {
			 
			//Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			 
			Vector3 MousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			dragPic.transform.position = new Vector3 (MousePosi.x+0.2f, MousePosi.y, -3);
		}  
	}
}
