using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlSomeUIAndOtherWin : MonoBehaviour {
    //预设无数个gameobject窗体，每一个的初始化都需要接受一定的信息。

    //private static ControlSomeUIAndOtherWin ThisControlUIWINDOW ;
    //public static ControlSomeUIAndOtherWin GetUIWINDOW() {
    //    if (ThisControlUIWINDOW == null) {

    //        ThisControlUIWINDOW= new ControlSomeUIAndOtherWin();
    //        return ThisControlUIWINDOW;

    //    }
    //    return ThisControlUIWINDOW;

    //}
    [SerializeField] List<GameObject> EveryWindows=new List<GameObject>();
    [SerializeField] List<GameObject> WindowsThatAwake = new List<GameObject>();
    [SerializeField] Text TalkVEnterInforMation;
	void Start ()
    {

        EveryWindows[0].SetActive(false);
        EveryWindows[1].SetActive(false);

	}
    private void FixedUpdate()
    {
        //当有视窗被激活的时候，不允许用户操作主角;而没有的时候，允许用户操作主角
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            for (int i = 0; i < EveryWindows.Count; i++)
            {
                if (EveryWindows[i].activeSelf) {
                    EveryWindows[i].SetActive(false);
                    return;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {

                
             
        }
        if (Input.GetKeyDown(KeyCode.B))
        { 
             
            
            
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Return))
        {   
            
            
            
        }   
    }
    public void OpenBagWins() {

        EveryWindows[0].SetActive(true);

    }
    //对话视窗=======V，两个enter可以停止这个交互，而esc是没用的          （C，Enter）
    public void SetTalkThatEnterAndV(string Infor) {

        Debug.Log("调用了");
        EveryWindows[2].SetActive(true);
        Debug.Log(EveryWindows[2].name);
        TalkVEnterInforMation.text = Infor;

    }
    //提示视窗========任意键都可以停止这个交互                             (Anykey)
    public void SetTalkToTellSomeInfor(string Infor)
    {



    }
    //象征性提示视窗=======正在加载等交互                                   (NONE)
    public void SetTalkThatCnotCloseByPlayer(string Infor) {



    }
    //象征性提示视窗，隐藏同名视窗                                          (NONE)
    public void DelTalkThaitCnotCLoseByPlayer(string Infor) {



    }
    //警告视窗====这个比较多
    //武器视窗，这个就是EveryWindows[0]那个，这个视窗应该是可以被esc停止的  (ESC)
        
}
