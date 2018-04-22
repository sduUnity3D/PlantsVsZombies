using UnityEngine;

public class Shop : MonoBehaviour {

	public plantBluePrint plant1;
	public plantBluePrint plant2;
	public plantBluePrint plant3;
	public GameObject pic1;
	public GameObject pic2;
	public GameObject pic3;
	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}


	//按钮事件
	public void SelectPlant1 ()
	{
		buildManager.useShovel = false;
		buildManager.SelectTurretToBuild (plant1);
		GameObject picObject =  Instantiate (pic1 );
		buildManager.dragPic = picObject;
	}

	public void SelectPlant2()
	{
		buildManager.useShovel = false;
		buildManager.SelectTurretToBuild(plant2);
		GameObject picObject =  Instantiate (pic2);
		buildManager.dragPic = picObject;
	}

	public void SelectPlant3()
	{
		buildManager.useShovel = false;
		buildManager.SelectTurretToBuild(plant3);
		GameObject picObject =  Instantiate (pic3);
		buildManager.dragPic = picObject;
	}

}
