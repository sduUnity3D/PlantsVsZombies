using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public interface IUI_interface{
    void OnPlanted(int type,Vector3 position);
    void OnEarsed(Vector3 position);
 }

public class UI_controler : MonoBehaviour
{
    //控件
	GameObject cube;
	GameObject mylight;

	GameObject tab1;
	GameObject tab2;
    GameObject tab3;
    private Image image;
    Button btn_plant1;
    Button btn_plant2;
    Button btn_plant3;
    Image image_plant1;
    Image image_plant2;
    Image image_plant3;
    Button earse;
    Button switchbtn;
    Text txt_suns;
    Button btn_start;
	Button btn_restart;
    Button btn_exit1;
    Button btn_exit2;
    Button btn_menu;
    Image img_active;
    Slider slider_process;
    Slider slider_volume;
    //音频
    AudioSource music;
    //控制变量
	bool isRun=false ;
    bool isImgClick = true;
    bool isDrag = false;
    //数据变量
    float volume=1;
    int isDragType = 0;
    int[] sunsneed = new int[3] { 50, 100, 150 };
    bool[] isActivelist = new bool[3] { false, false, false };
    int suns = 1000;
    //接口
    IUI_interface listener;
    // Use this for initialization
    void Start () {
        //初始化对象
		cube = GameObject.Find("Cube");
		mylight = GameObject.Find ("Light");
        tab1 =GameObject.Find("UI_start");
		tab2= GameObject.Find("UI_pause");
        tab3 = GameObject.Find("UI_playing");

        //初始化按钮并添加点击事件
		btn_start = (Button) GameObject.Find ("btn_start").GetComponent<Button> ();
		btn_start.onClick.AddListener (delegate() { SwitchTab(1); });
		btn_restart = (Button) GameObject.Find ("btn_restart").GetComponent<Button> (); 
		btn_restart.onClick.AddListener (delegate() { SwitchTab(2); });
        btn_menu= (Button)GameObject.Find("btn_menu").GetComponent<Button>();
        btn_menu.onClick.AddListener(delegate() { SwitchTab(3); });
        btn_exit1 = (Button)GameObject.Find("btn_exit1").GetComponent<Button>();
        btn_exit2=(Button)GameObject.Find("btn_exit2").GetComponent<Button>();
        btn_exit1.onClick.AddListener(Exit);
        btn_exit2.onClick.AddListener(Exit);

        //初始化植物列表按钮
        btn_plant1 = (Button)GameObject.Find("image_plant1").GetComponent<Button>();
        btn_plant2 = (Button)GameObject.Find("image_plant2").GetComponent<Button>();      
        btn_plant3 = (Button)GameObject.Find("image_plant3").GetComponent<Button>();
        btn_plant1.onClick.AddListener(delegate () { click(1); });
        btn_plant2.onClick.AddListener(delegate () { click(2); });
        btn_plant3.onClick.AddListener(delegate () { click(3); });
        image_plant1 = (Image)GameObject.Find("image_plant1").GetComponent<Image>();
        image_plant2 = (Image)GameObject.Find("image_plant2").GetComponent<Image>();
        image_plant3 = (Image)GameObject.Find("image_plant3").GetComponent<Image>();
        earse = (Button)GameObject.Find("image_earse").GetComponent<Button>();
        earse.onClick.AddListener(delegate () { click(4); });
        
        //初始化其他控件
        txt_suns = (Text)GameObject.Find("txt_suns").GetComponent<Text>();
        slider_process=(Slider)GameObject.Find("slider_process").GetComponent<Slider>();
        slider_volume = (Slider)GameObject.Find("slider_music").GetComponent<Slider>();

        //拖拽图片对象 并动态绑定鼠标事件
        image = (Image)GameObject.Find("image_active").GetComponent<Image>();
        image.gameObject.SetActive(false);
        
        EventTrigger trigger = image.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener(OnPointerUp);
        trigger.triggers.Add(entry);

        //初始化音频
        music = (AudioSource)GameObject.Find("Audio Source").GetComponent<AudioSource>();
        music.Stop();

        //初始化布局
        tab2.SetActive (false);
        tab3.SetActive(false);

	}
	// Update is called once per frame
	void Update () {
		if (isRun) {
            //物体旋转
			cube.transform.Rotate (Vector3.up*10* Time.deltaTime);
            mylight.transform.RotateAround (cube.transform.position,Vector3.up,50* Time.deltaTime);
            //更新阳光

            //更新进度
            slider_process.value+=Time.deltaTime* (float)0.05;
            //更新音量
            music.volume = slider_volume.value;
            //在拖拽中实时更新图片的额位置信息
            if (isDrag)
            {
                Vector3 position = Input.mousePosition;
                image.transform.position = new Vector3(position.x, position.y, image.transform.position.z);
            }
            //更新植物列表
            int sign = suns / 50;
            switch (sign)
            {
                case 0:
                    setImageActive(0);
                    break;
                case 1:
                    setImageActive(1);
                    break;
                case 2:
                    setImageActive(2);
                    break;
                case 3:
                    setImageActive(3);
                    break;
                default:
                    setImageActive(3);
                    break;
            }
        }
        //监听空格键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRun)
            {
                //游戏暂停
                isRun = false;
                this.tab2.SetActive(true);
                tab3.SetActive(false);
                music.Pause();
            }
            else
            {
                isRun = true;
                this.tab2.SetActive(false);
                tab3.SetActive(true);
                music.Play();
            }
        }
        
    }//end of Upadate

    //界面切换
    void SwitchTab(int tab) {
        if (tab == 1) {
            if (!isRun)
            {
                isRun = true;
                this.tab1.SetActive(false);
                this.tab3.SetActive(true);
                music.Play();
            }
        } else if (tab==2) {
            if (!isRun)
            {
                isRun = true;
                this.tab2.SetActive(false);
                tab3.SetActive(true);
                SetSuns(++suns);
                music.Play();
            }
        } else if (tab==3) {
            if (isRun) {
                isRun = false;
                tab2.SetActive(true);
                tab3.SetActive(false);
                music.Pause();
            }
        }
    }
    public void click(int index)
    {

        switch (index)
        {
            case 1:
                if (isActivelist[0])
                {
                    //设置拖拽图片的起始位置
                    image.transform.position = new Vector3(btn_plant1.transform.position.x, btn_plant1.transform.position.y, btn_plant1.transform.position.z);
                    //动态加载图片
                    image.sprite = Resources.Load("image/plant1", typeof(Sprite)) as Sprite;
                    isDrag = true;
                    isDragType = 1;
                    image.gameObject.SetActive(true);
                }
                break;
            case 2:
                if (isActivelist[1])
                {
                    image.transform.position = new Vector3(btn_plant2.transform.position.x, btn_plant2.transform.position.y, btn_plant2.transform.position.z);

                    image.sprite = Resources.Load("image/plant2", typeof(Sprite)) as Sprite;
                    isDrag = true;
                    isDragType = 2;
                    image.gameObject.SetActive(true);
                }
                break;
            case 3:
                if (isActivelist[2])
                {
                    image.transform.position = new Vector3(btn_plant3.transform.position.x, btn_plant3.transform.position.y, btn_plant3.transform.position.z);

                    image.sprite = Resources.Load("image/plant3", typeof(Sprite)) as Sprite;
                    isDrag = true;
                    isDragType = 3;
                    image.gameObject.SetActive(true);
                }
                break;
            case 4:
                image.transform.position = new Vector3(earse.transform.position.x, earse.transform.position.y, earse.transform.position.z);

                image.sprite = Resources.Load("image/earse", typeof(Sprite)) as Sprite;
                isDrag = true;
                isDragType = 0;
                image.gameObject.SetActive(true);

                break;
        }
    }
    void OnPointerUp(BaseEventData eventData)
    {
        Debug.Log(2);
        //结束拖拽过程
        if (isDrag)
        {
            isDrag = false;
            //用于发送种植信息
            if (isDragType != 0)
            {
              
               // listener.OnPlanted(isDragType, Input.mousePosition);
            }
            else {
               // listener.OnEarsed(Input.mousePosition);
            }

            image.gameObject.SetActive(false);
            Debug.Log(1);
            if (isDragType > 0)
            {
                suns = suns - sunsneed[isDragType - 1];
                txt_suns.text = "阳光:" + suns;
            }

        }
    }
    void SetSuns(int _suns) {
        this.suns = _suns;
    }
    void Setprocess(int _value) {
        this.slider_process.value = _value;
    }
    void SetVolume(int _volume) {
        this.music.volume = _volume;
        this.slider_volume.value = _volume;
    }
    void Exit() {
        Application.Quit();
    }
    public void setImageActive(int index)
    {
        Color disable = Color.gray;
        Color active = Color.white;
        switch (index)
        {
            case 0:
                isActivelist[0] = false;
                image_plant1.color = disable;
                isActivelist[1] = false;
                image_plant2.color = disable;
                isActivelist[2] = false;
                image_plant3.color = disable;
                break;
            case 1:
                isActivelist[0] = true;
                image_plant1.color = active;
                isActivelist[1] = false;
                image_plant1.color = disable;
                isActivelist[2] = false;
                image_plant1.color = disable;
                break;
            case 2:
                isActivelist[0] = true;
                image_plant1.color =active;
                isActivelist[1] = true;
                image_plant1.color = active;
                isActivelist[2] = false;
                image_plant1.color = disable;
                break;
            case 3:
                isActivelist[0] = true;
                image_plant1.color = active;
                isActivelist[1] = true;
                image_plant1.color = active;
                isActivelist[2] = true;
                image_plant1.color = active;
                break;
        }
    }
    void setListener(IUI_interface _listener) {
        this.listener = _listener;
    }
}
