using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainControl : MonoBehaviour {
    private bool InArriveGame;
    private bool ArriveGame {
        get { return InArriveGame; }
        set {
            if (value) {

                WindowsWarningOfNewGame.SetActive(false);
                WindowsNewGameOk.SetActive(false);
                InNewGameWindow = false;
                NewGame.SetActive(false);
                InNewGame = false;

                WindowsWarningOfGallery.SetActive(false);
                InGalleryWindow = false;
                Gallery.SetActive(false);
                InGallery = false;

                WindowsWarningOfLoadGame.SetActive(false);
                InLoadSettingWindow = false;
                LoadGame.SetActive(false);
                InLoadSetting = false;
              
            }


        }

    }
    private bool InNewGame;
    private bool InGallery;
    private bool ingallerywindow;
    private bool InGalleryWindow {
        get{ return ingallerywindow; }
        set{ if (!InGallery) return;
            else ingallerywindow = value;
        } }
    private bool innewgamewindow;
    private bool InNewGameWindow {
        get {return innewgamewindow; }
        set{ if (!InNewGame) return;
            else innewgamewindow = value;
 } }

    private bool InLoadSetting;
    private bool inloadsettingwindow;
    private bool InLoadSettingWindow
    {
        get{return inloadsettingwindow; }
        set {if (!InLoadSetting) return;
            else inloadsettingwindow = value;}

    }

    //拥有的外置财富都在这里显现
    //地图储存亦然 
    // Use this for initialization
    [SerializeField] List<Button> StartMenu = new List<Button>();
    [SerializeField] GameObject Gallery;
    [SerializeField] GameObject NewGame;
    [SerializeField] GameObject LoadGame;

    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            InputEscape();
        }
    }
    public void ClickNewGame() {
        if (InNewGame || InGallery || InLoadSetting)
        {
            return;
        }
        InNewGame = true;
        NewGame.SetActive(true);
    }
    public void ClickGallery() {
        if (InNewGame || InGallery || InLoadSetting)
        {
            return;
        }
        InGallery = true;
        Gallery.SetActive(true);
        //检查一下页码之类的，归于0并检查有没有新的壁纸获取。
    }
    public void ClickLoadSetting() {
        if (InNewGame || InGallery || InLoadSetting)
        {
            return;
        }
        LoadGame.SetActive(true);
        InLoadSetting = true;

    }
    public void CloseGallery() {
        //重置Gallery页码到0之后
        Gallery.SetActive(false);

    }

    private void InputEscape()
    {
        Debug.Log("111111" + InNewGame + InGallery + InLoadSetting);
        if (!InNewGame && !InGallery && !InLoadSetting)
        {
            return;
        }
        Debug.Log("222222");
        if (InGallery)
        {
            if (InGalleryWindow)
            {
                WindowsWarningOfGallery.SetActive(false);
                InGalleryWindow = false;
                //关闭窗口
            }
            else
            {

                //关闭gallery
        
                Gallery.SetActive(false);
                InGallery = false;
            }

        }


        if (InNewGame)
        {
            if (InNewGameWindow)
            {
                WindowsWarningOfNewGame.SetActive(false);
                WindowsNewGameOk.SetActive(false);
                InNewGameWindow = false;
                //关闭最上层的窗口

            }
            else {
                NewGame.SetActive(false);
                InNewGame = false;
                
            }

            //关闭newgame窗口
      
        }
        if (InLoadSetting)
        {
            if (InLoadSettingWindow)
            {

                return;

            }
            else
            {
                LoadGame.SetActive(false);
                //关闭loadsetting窗口
                InLoadSetting = false;
            }

        }
    }
        //gallery状态，如果处于窗口，那么关闭选项，否则取消当前壁纸的全屏和取消当前壁纸状态
        //newgame状态，如果处于窗口，那么一层一层地关闭,否则关闭
        //loadsetting状态，如果处于窗口那么无效，否则关闭

    [SerializeField] GameObject WindowsWarningOfNewGame;
    [SerializeField] GameObject WindowsNewGameOk;
    public void ClickButtonOfNewGame()
    {
        WindowsWarningOfNewGame.SetActive(true);
        WindowsNewGameOk.SetActive(true);
        InNewGameWindow = true;
    }
    public void ClickWindowsWarningOfNewGame()
    {
        WindowsWarningOfNewGame.SetActive(false);
        WindowsNewGameOk.SetActive(false);
        InNewGameWindow = false;
    }
    public void ClickIWillPlayGameMode_1() {
        ArriveGame = true;

        //加载gamemode_1了 
        //GameManager_1的 StartGameMode_
        GameObject.Find("GameManager_1Empty").GetComponent<GameManager_1>().StartGameMode_1();
    }



    [SerializeField] GameObject WindowsWarningOfLoadGame;
    public void ClickButtonOfLoadGame()
    {
        WindowsWarningOfLoadGame.SetActive(true);
        InLoadSettingWindow = true;
    }
    public void ClickWindowsWarningOfLoadGame()
    {
      
        WindowsWarningOfLoadGame.SetActive(false);
        InLoadSettingWindow = false;
    }


    [SerializeField]GameObject ButtonOfGallery;
    [SerializeField]GameObject WindowsWarningOfGallery;
    public void ClickButtonOfGallery() {
        WindowsWarningOfGallery.SetActive(true);
        InGalleryWindow = true;
    }
    public void ClickWindowsWarningOfGallery() {
        WindowsWarningOfGallery.SetActive(false);
        InGalleryWindow = false;
    }
}
