using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Class_1;
public class SingleMode_1 : MonoBehaviour {
    //生命值
    [SerializeField] private GameObject Player;
    [SerializeField] private Image Hp;
    [SerializeField] private Image Breathe;
    [SerializeField] private float playerlife;
    
    private float PlayerLife
    {
        get{
            return playerlife;
        }
        set
        {
            if (value <100 && value > 0)
            {
                FromLifeToLife(playerlife, value);
                //   Hp.fillAmount = value * 0.01f;
                onreducing = true;
            }
            else if (value <= 0)
            {
                FromLifeToLife(playerlife, 0);
                //  Hp.fillAmount = 0f;
                //死亡后的dosomething
            }
            else {
                //   Hp.fillAmount = 1;
                FromLifeToLife(0, 100);
                onreducing = false;
                recovertime = 400;
            }
            playerlife = value;
        }
    }

    //呼吸

    //呼吸回血
    private bool onreducing = false;
    private int recovertime;
    private int RecoverTime
    {
        set
        {
            if (!onreducing) {
                return;
            }
            if (value <= 0)
            {

                //进行一次回血
                PlayerLife = 100;
                recovertime = 400;
            }
            else { recovertime = value; }
        }

        get { return recovertime; }
    }

    /*肺内有效气体 窒息程度 处于迷雾状态会不断减少 
     *判断处于迷雾中？
         
         */
    [SerializeField] private float breatheleft;
    private float BreatheLeft {
        get { return breatheleft; }
        set {
            if (breatheleft <= 0&& value <= 0) {
                PlayerLife -= 0.01f;

            }
            //dosomething UI
            if (value > 5000)
            {
                breatheleft = 5000;
                Breathe.fillAmount = 0.981f;
                return;
            }
            if (value <= 0)
            {
                breatheleft = 0;
                Breathe.fillAmount = 0.081f;
            }
            else
            {
                breatheleft = value;
                Breathe.fillAmount = 9 * value / 50000 + 0.081f;
            }
            
           
    
        }

    }
    private IEnumerator C;
    private void FromLifeToLife(float from,float to) {
        if (from >= 0 && to >= 0)
        {
            if (C != null) { StopCoroutine(C); }
          
            C = FromTo(from, to);
            StartCoroutine(C);

        }
        else if (from * to < 0)
        {
            if (from < 0) {
                if (C != null) { StopCoroutine(C); }
                C = FromTo(0, to);
                StartCoroutine(C);

            } else {

                if (C != null) { StopCoroutine(C); }
                C = FromTo(from, 0);
                StartCoroutine(C);

            }


        }
        else {

            return;
        }

    }
    IEnumerator FromTo(float from,float to) {
        int j;
        j = from > to ? -1 : 1;
        for (int i = 1; i < -j * ( from - to )+1; i++)
        {
            Hp.fillAmount= (from + i * j) * 0.01f; 
            yield return null;
        }

    }
    public void InFog(int FogLevel) {

        BreatheLeft -= 2 * FogLevel;
        
    }
    public void InBreath(int AirLevel,int FogLevel) {
        if (AirLevel > FogLevel)
        {
            BreatheLeft += 20 * (AirLevel - FogLevel);
        }

    }
    [SerializeField]private bool IsInFog = false;
    int ii = 2;
    public void GetEventInFog(int AirLevel,int FogLevel) {
      //  Debug.Log("A");
        IsInFog = true;
        ii = 2;
        InFog(FogLevel);
        InBreath(AirLevel,FogLevel);

    }
    //IEnumerator CanBeInjuryByFog() {

    //    yield return new WaitForSeconds(2f);

    //}
    //基地   start position  end position     
    [SerializeField]private GameObject StartPosition;
    [SerializeField]private GameObject EndPosition;
    [SerializeField]private Vector3 ColliderSize;
    // Use It When Start()
    void StartEndPosition() {
        Player.transform.position = StartPosition.transform.position;



        BoxCollider EndCollider = EndPosition.AddComponent<BoxCollider>();
        EndCollider.isTrigger = true ;
        EndCollider.size = ColliderSize;
        
    }



    //胜利目标  end position


    //子弹 弹夹 怪物  
    [SerializeField] private TenBullet tenBullet;
    public void OneShot(int BulletLeft) {

        tenBullet.TransBullet(BulletLeft);

    }
    //背包
    [SerializeField] private GameObject BagGameObject;
    [SerializeField] private GameObject PanelGameObject;
    private void WhenWindowsUI_Consu() {
        Time.timeScale = 0;
        Cursor.visible = true;
        BagGameObject.SetActive(true);
        PanelGameObject.SetActive(true);

    }
    private void WhenEscCape() {
        Time.timeScale = 1;
        Cursor.visible = false;
        BagGameObject.SetActive(false);
        PanelGameObject.SetActive(false);

    }
    //背包的初始值应该是从dontdestroy里面得到的，剩下的就是一个框架
    private Consu [] ConList=new Consu[50];
    private Weapen[] WeaponList = new Weapen[14];
    private Consu ThisConsu;
    private Weapen ThisWeapon;
    private int NowIsWhat;
    //捡东西           
    private void ReFresh(int What) {

        ThisWeapon = Bag.SingleBag().GetWeapenList(What);

    }
    public void _UIWeapon(DataOfGun[] _dataOfGun,int FromWhat,int ToWhat) {

        //武器UI

    }  
    // Use this for initialization
    void Start () {
        StartEndPosition();
        Breathe.fillAmount = 0.981f;
        PlayerLife = 100;
        RecoverTime = 400;
        GameStart();
        BreatheLeft = 5000;
        WhenEscCape();
    }
    private void FixedUpdate()
    {

        



        //  Debug.Log("B");

        if (IsInFog)
        {
            ii--;
            //
            if (ii == 0) {
                IsInFog = false;
                ii = 2;
            }
            
        }
        else
        {
           // Debug.Log("Once");
            InBreath(1, 0);
            //huixue
        }


        // Debug.Log(Hp.fillAmount+""+onreducing);
        if (onreducing) {
            RecoverTime--;
        }
        
    }
    // Update is called once per frame
   
    void Update () {

        if (Input.GetKeyDown(KeyCode.B))
        {
          
            WhenWindowsUI_Consu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            WhenEscCape();
        }

    }
    public void GameStart() {

        //访问从上个eventsystem跑进来的dontdestroy里面的储存信息，确认拥有什么初始道具，确认这是什么模式的游戏，确认地图是什么并加载

    }


}
