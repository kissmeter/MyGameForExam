﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRigid : MonoBehaviour {
    Rigidbody ThisRI;
    [SerializeField] GameObject Probe;
    [SerializeField] CapsuleCollider PlayerCapsule;
    [SerializeField] ParticleSystem GetAparticle;
    [SerializeField] List<GameObject> GameObjectThatTriggerGet;
    [SerializeField] GameObject Gun;
    private RaycastHit hitInfo;
    private Vector3 InputForce;
    private bool isrunning = false;
    private bool isjumping = false;
    //private Vector3 ThisFaceWorldPointIn;
    //private Vector3 ThisRightWorldPointIn;
    // Use this for initialization
    void Start () {
        ThisRI = this.gameObject.GetComponent<Rigidbody>();
        GetAparticle.Stop();

    }
    // 游戏改host
    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("NormalFace()"+NormalFace());
        //非但是在空中，处于编辑状态等状态下也不能继续控制移动和跳跃了
        InputForce = NormalFace();
        if (IsInGround()&&isrunning)
        {
            isrunning = false;
            Debug.Log("触发了");
            ThisRI.velocity = new Vector3(0, 0, 0);
            ThisRI.AddForce(InputForce, ForceMode.Impulse);
        }

        if (IsInGround() && Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
            ThisRI.velocity = new Vector3(0, 0, 0);
            ThisRI.AddForce(new Vector3(0, 5f, 3 * transform.forward.z), ForceMode.Impulse);
        }
        if (Input.GetButtonDown("Fire2")) {
            //   Debug.Log("射击了");
            //发射了一发子弹
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
            GameObject.Find("AimControl").GetComponent<AimControlScript>().IfShotAtOnece();
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到
                GameObject gameObj = hitInfo.collider.gameObject;
                Debug.Log("click object name is " + gameObj.name + "" + hitInfo.point);
                StartCoroutine(ControlKnifeAndUi.GetControlKU().ParticleCorat(hitInfo.point, ControlKnifeAndUi.GetControlKU().TheNext()));
                StartCoroutine(ControlKnifeAndUi.GetControlKU().HitUiOnSky(hitInfo.point, ControlKnifeAndUi.GetControlKU().TheNext(), "99999999", Color.red));
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
     

        //}
        //============================================
        //F依然是一个不需要多重按键的，但是考虑到按键修改，必须考虑到这里改成input预设，在此记下，在完善的时候需要注意
        //============================================
        if (Input.GetKeyDown(KeyCode.F)) {
            //理论上来说，获取一定距离内NPC的方式 1，依然是中介者模式   2，添加5尺碰撞盒，在这一瞬间获取NPCtag  3，交付 
            //在这里用一下探针
            Probe.SetActive(true);
            Probe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.5f * this.PlayerCapsule.height, this.transform.position.z);
          //  Probe.GetComponent<EventForCollider>().TransTriggerBool(this);
        }
        if (Input.GetKeyDown(KeyCode.J)) {

            Skill_JumpBack();
        }
    }
    public void Skill_JumpBack()
    {
        if (IsInGround())
        {
            Debug.Log("开始飞了");
            isjumping = true;
            ThisRI.velocity = new Vector3(0, 0, 0);
            ThisRI.AddForce(new Vector3(-2 * transform.forward.x, 2f, -2 * transform.forward.z), ForceMode.Impulse);

        }
        else
        {
            //提示不符合技能释放条件

        }

    }
    //public void GetThisTriggerGameObject(List<GameObject> list) {

    //    GameObjectThatTriggerGet = list;
    //    CompareDistanceAndUseTalk();

    //}
    //private Vector3 ThisFaceWorldPoint() {
    //    ThisFaceWorldPointIn = transform.forward.normalized;
    //    return ThisFaceWorldPointIn;
    //}
    //private Vector3 ThisRightWorldPoint() {
    //    ThisRightWorldPointIn = transform.right.normalized;
    //    return ThisRightWorldPointIn;

    //}
    private Vector3 NormalFace() {
       // Vector3 SpeedAndVector=new Vector3(0,0,0);
        Vector2 WOnly=new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            //  Debug.Log("transform.forward" + transform.forward);
            //  Debug.Log(this.transform.right);
            
            WOnly += new Vector2(this.transform.forward.normalized.x,this.transform.forward.normalized.z);
            isrunning = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            WOnly += new Vector2(-this.transform.forward.normalized.x, -this.transform.forward.normalized.z);
            isrunning = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
           
            WOnly += new Vector2(-this.transform.right.normalized.x , -this.transform.right.normalized.z);
            isrunning = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
           
            WOnly += new Vector2(this.transform.right.normalized.x, this.transform.right.normalized.z);
            isrunning = true;
        }

        //Debug.Log("WOnly.normalized"+WOnly.normalized);
       // SpeedAndVector =new Vector3(WOnly.normalized.x * (float)0.1,0, WOnly.normalized.y * (float)0.1);
        return new Vector3(WOnly.normalized.x * 1f, 0, WOnly.normalized.y * 1f);

    }
 
        private bool IsInGround() {
      
        if (Mathf.Abs(ThisRI.velocity.x + ThisRI.velocity.y + ThisRI.velocity.z) <= 0.1) {
           // Debug.Log("静止了！");
            if (isjumping) { return false; }
            return true;
        }
        Ray ray = new Ray(this.gameObject.transform.position, new Vector3(0, -1, 0));
        RaycastHit RayForGround;
        if (Physics.Raycast(ray, out RayForGround))
        {
            Debug.DrawLine(ray.origin, RayForGround.point);//划出射线，在scene视图中能看到由摄像机发射出的射线
            GameObject gameObj = RayForGround.collider.gameObject;
            //if (gameObj.name.StartsWith("Cube") == true)//当射线碰撞目标的name包含Cube，执行拾取操作
            //{
            //    Debug.Log(gameObj.name);
            //}
            float Distance = this.gameObject.transform.position.y - RayForGround.point.y;
            // Debug.Log(Distance);
            if (Distance < 0.51f * PlayerCapsule.height) {
                isjumping = false;
               // Debug.Log("此时踩着了");
                return true; }
            else { return false; }
           

        }
        return false;

        }

}
