using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour {
    [SerializeField] Text Infor;
    [SerializeField] Text GunRoomText;
    private int isInNumberWhatGun;

    //这是第一人称，负责上传自己的射击信息 
    #region 射击信息应该包含什么
    /*
     对于一个人，他的射击信息内应该包含 
     拥有枪支内容，改变枪支内容（捡到和丢弃），每一个枪支的信息 
     而这里先仅仅使用一把枪，而枪改变也就是以下数值的改变罢了 
    private int GunNum;             枪支编码
    private string GunName;         枪支名字
    private GameObject GunPrefab;   枪支模型（先不考虑）
    private float GunShotSpeed;     枪支射击间隔 
    private int GunRoom;            弹夹容量
    private float TimeOfFilling;    装填时间
         */
    #endregion


    //换武器之后，会改变以下所有的数值，换武器结束和换武器失败（如果死亡或者在换武器期间换武器，那么换武器失败）
    //这些数值在储存 DataOfGun上。
    //如果我用四个位置储存四个武器,切换武器是调用这四个位置的datagun，而更换武器是换掉其中某个datagun
    //切换到某个位置的武器：进行一次放下+拿起动画，切换到某个武器位置，如果此时正在换弹，射击和更换武器，那么拒绝 
    //捡到一个武器： 进行一次拿起动画，如果我的装备列表是有空的，那么放进其中一个，如果此时正在换弹，射击和更换武器，那么拒绝 
    //更换一个武器（替换）：进行一次拿起动画，如果反之，那么替换掉我当前的武器位置 ，如果此时正在换弹，射击和更换武器，那么拒绝 
    //丢弃一个武器：清掉当前的武器位置，如果此时正在换弹，射击和更换武器，那么拒绝 

    //如果我拥有四个快捷栏，这四个包含武器和消耗品。我按了其中一个，会产生“切换到武器命令”和“切换到消耗品命令”，在这里的切换到武器命令应该是
    //中介者模式判定之后的。换句话说，这四个东西储存的是什么，不归这个gun管，这个gun只负责接收到这些事件罢了 ，因此上面这几行不适用，就连动画都不归他管 
    //这里应该拥有的方法
    //改变到一个武器（开启这个协程之前要关闭所有这个协程，这期间还不允许干别的，结束之后才改变所有信息，如果失败，那么不改变信息）
    private float GunShotSpeed=(float)0.3;
    private float TimeOfFilling=(float)1.5;
    private int GunRoom=14;

    private bool isenable = true;
    private bool isshot    =false;
    private bool isfilling = false;
    private bool istraning = false;//正在换武器 
    private bool isskilling = false;
    private Coroutine C;
    void Start () {
        OneGunProperty.GetGunProperty();
        string sss = "是发发发发"; 
    }
	
	// Update is called once per frame
	void Update () {
        if (!isenable) { return; }
      //  if (PropWindowsManager.isgetgun) { return; }
        if (Input.GetKeyDown(KeyCode.R)) {
            WhenREvent();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            WhenMouseDownEvent();
        }
    }
    public void TransToAGun(DataOfGun TransToGun) {
        isenable = true;//只要我现在不是切入到武器，否则我是不接受射击事件的

        //if()
        //协程不写在这里，调用说明已经换成了它，替换掉所有信息,可能这个方法要在动画状态机里面安插一个事件(event)来调用  
        GunShotSpeed = TransToGun.GiveGunShotSpeed();
        TimeOfFilling = TransToGun.GiveTimeOfFilling();
        GunRoom = TransToGun.GiveGunRoom();

    }
    //这两个是指换枪期间不允许做事情 
    public void YouCantDoAnyMore() {
        StopAllCoroutines();
        isshot = false;
        isfilling = false;
        isenable = false;
    }
    public void YouCanDoNow() {

        isenable = true;
    }
    public void TransToNotGun() {
        isenable = false;

    }
    void FixedUpdate()
    {
        GunRoomText.text = GunRoom.ToString();
    }

    void WhenREvent() {
     
        if (isshot)     { return; }
        if (isfilling)  { return; }
        if (istraning)  { return; }
        if (isskilling) { return; }
        C = StartCoroutine(StartFill());
    }
    void WhenMouseDownEvent() {
        if (isshot)     { return; }
        if (isfilling)  { return; }
        if (istraning)  { return; }
        if (isskilling) { return; }
        if (GunRoom <= 0) { return; }
        C = StartCoroutine(StartShot());
    }
    void WhenNumberDownEvent(int number) {
        if (number == isInNumberWhatGun) { return; }
        if (isshot)     { return; }
        if (isfilling)  { return; }
        if (istraning)  { return; }
        if (isskilling) { return; }
        //切武器，可能包含放下当前武器和取出新武器两个动作 
    }
    IEnumerator  StartShot() {
        GunRoom--;
        Infor.text += "\n射击中";
        isshot = true;
        yield return new WaitForSeconds(GunShotSpeed);
        Debug.Log(isshot);
        Infor.text += "\n射击结束";
        isshot = false;
    }
    IEnumerator StartFill() {
        
        Infor.text += "\n装填中";
        isfilling = true;
        yield return new WaitForSeconds(TimeOfFilling);
        Infor.text += "\n装填结束";
        GunRoom =14;
        isfilling = false;
    }

}
