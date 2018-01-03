using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropWindowsManager : MonoBehaviour {
    //复制 
    //换武器之后，会改变以下所有的数值，换武器结束和换武器失败（如果死亡或者在换武器期间换武器，那么换武器失败）
    //这些数值在储存 DataOfGun上。
    //如果我用四个位置储存四个武器,切换武器是调用这四个位置的datagun，而更换武器是换掉其中某个datagun
    //切换到某个位置的武器：进行一次放下+拿起动画，切换到某个武器位置，如果此时正在换弹，射击和更换武器，那么拒绝 
    //捡到一个武器： 进行一次拿起动画，如果我的装备列表是有空的，那么放进其中一个，如果此时正在换弹，射击和更换武器，那么拒绝 
    //更换一个武器（替换）：进行一次拿起动画，如果反之，那么替换掉我当前的武器位置 ，如果此时正在换弹，射击和更换武器，那么拒绝 
    //丢弃一个武器：清掉当前的武器位置，如果此时正在换弹，射击和更换武器，那么拒绝 

    //如果我拥有四个快捷栏，这四个包含武器和消耗品。我按了其中一个，会产生“切换到武器命令”和“切换到消耗品命令”，在这里的切换到武器命令应该是
    int[] SkillWindows = new int[4];
    
    private int ThisNumber;
    IEnumerator IsIEnumerator;
    private GameObject FirstPlayer;
    PlayerShot playerShot;
    // Use this for initialization
    void Start () {

        FirstPlayer = GameObject.Find("RigidBodyFPSController");
        playerShot = (PlayerShot)FirstPlayer.GetComponent<PlayerShot>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //得到一个新的武器信息 
    //public DataOfGun GetAGun() {

    //}
    //得到一个新的道具信息
    //public DataOfGun GetAGun()
    //{

    //}

    public void InputNumberToChangeGun(int Input) {
        if (IsIEnumerator != null)
        { 
        StopCoroutine(IsIEnumerator);
        }   
        if (Input <= 0) { return; }
       
        if (ThisNumber == Input) { return; }
        if (Input <= 100000)
        {
            IsIEnumerator = ChangeGun(Input);
            StartCoroutine(IsIEnumerator);
        }
        else if (Input <= 200000) { }

        else if (Input <= 300000) { }
    
        
    }
    IEnumerator ChangeGun(int Input) {
        playerShot.YouCantDoAnyMore();
        yield return new WaitForSeconds(2f);
        playerShot.YouCanDoNow();
        IsIEnumerator = null;
        ThisNumber = Input;
    }
    IEnumerator ChangeCONSU(int Input)  //消耗品 
    {
        playerShot.YouCantDoAnyMore();
        yield return new WaitForSeconds(2f);
        playerShot.YouCanDoNow();
        IsIEnumerator = null;
        ThisNumber = Input;
    }
    //更换技能和上面的不同，它不需要动画 
    IEnumerator ChangeSkill(int Input)  //技能 
    {
        yield return null;
        IsIEnumerator = null;
        ThisNumber = Input;
    }

}
