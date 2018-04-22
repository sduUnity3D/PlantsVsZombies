using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class grasscube : MonoBehaviour {
	//public bool haveplant; 可以直接用plants变量是否来为空来判断。
	public GameObject plants;//已经在上面的植物
	public Vector3 positionOffset;//建造植物和原来位置的偏移量。
	private int i;

	BuildManager buildManager;
	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
	

		i = 0;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}


	//鼠标点击事件
	void OnMouseDown ()
	{
		Debug.Log ("mouse down");


		if (plants != null && buildManager.CanRemove) { //已经有植物并且可以移除的话，移除植物
			removeplant ();
			buildManager.DeUseShovel ();
			return;
		} else if (plants != null && !buildManager.CanRemove) {
			return;
		} else if (plants == null && buildManager.CanRemove) {
			buildManager.DeUseShovel ();
			return;
		}

		if (!buildManager.CanBuild) //判断是否可以建造，可以建造 的话则进行下一步的建造。
			return;
		Debug.Log ("to buidl");
		addplant(buildManager.GetPlantToBuild()); //没有植物，进行建造
		buildManager.DeSelectPlant();
	}

	// Update is called once per frame
	void Update () {
		
	}
	void addplant(plantBluePrint  thisPlant){
		if (!buildManager.HasMoney) {
			Debug.Log ("don't have enough money!");
			return;
		}
		playerStats.LightCount -= thisPlant.cost;//应该修改为植物的价格。


		GameObject hp_bar = thisPlant.plantPrefeb;
		hp_bar=Instantiate(hp_bar,GetBuildPosition(),Quaternion.identity);  

		//hp_bar.GetComponent<plantHealth> ().grass = gameObject; //一旦该植物被摧毁，将这个草地上的植物变量表示为空
		hp_bar.transform.parent = GetComponent<RectTransform> ();//?????
		//Debug.Log (plants.GetComponent<plantHealth> ().health);
		plants = hp_bar;
	}
	void removeplant(){
		
		plants.GetComponent<plantHealth> ().be_damage (9999f);
	}

}
