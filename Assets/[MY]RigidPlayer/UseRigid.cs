using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRigid : MonoBehaviour {
    Rigidbody ThisRI;
    [SerializeField]CapsuleCollider PlayerCapsule;
    [SerializeField] ParticleSystem GetAparticle;
    // Use this for initialization
    void Start () {
        ThisRI = this.gameObject.GetComponent<Rigidbody>();
        GetAparticle.Stop();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("NormalFace()"+NormalFace());
        //非但是在空中，处于编辑状态等状态下也不能继续控制移动和跳跃了
        if (!IsInGround())
        {
            ThisRI.AddForce(NormalFace(), ForceMode.Impulse);
        }
        if (!IsInGround() && Input.GetKeyDown(KeyCode.Space))
        {
            ThisRI.AddForce(new Vector3(0, 2f, 0), ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到
                GameObject gameObj = hitInfo.collider.gameObject;
                Debug.Log("click object name is " + gameObj.name + "" + hitInfo.point);
                StartCoroutine(ControlKnifeAndUi.GetControlKU().ParticleCorat(hitInfo.point,ControlKnifeAndUi.GetControlKU().TheNext()));
                StartCoroutine(ControlKnifeAndUi.GetControlKU().HitUiOnSky(hitInfo.point, ControlKnifeAndUi.GetControlKU().TheNext(), "99999999", Color.red));
            }

        }
    }



    private Vector3 NormalFace() {
       // Vector3 SpeedAndVector=new Vector3(0,0,0);
        Vector2 WOnly=new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("transform.forward" + transform.forward);
            //  Debug.Log(this.transform.right);
            WOnly += new Vector2(this.transform.forward.normalized.x,this.transform.forward.normalized.z);

        }
        if (Input.GetKey(KeyCode.S))
        {
            WOnly += new Vector2(-this.transform.forward.normalized.x, -this.transform.forward.normalized.z);

        }
        if (Input.GetKey(KeyCode.A))
        {
            WOnly += new Vector2(-this.transform.right.normalized.x , -this.transform.right.normalized.z);
          
        }
        if (Input.GetKey(KeyCode.D))
        {
            WOnly += new Vector2(this.transform.right.normalized.x, this.transform.right.normalized.z);
         
        }

        //Debug.Log("WOnly.normalized"+WOnly.normalized);
       // SpeedAndVector =new Vector3(WOnly.normalized.x * (float)0.1,0, WOnly.normalized.y * (float)0.1);
        return new Vector3(WOnly.normalized.x * (float)0.1, 0, WOnly.normalized.y * (float)0.1);

    }
        private bool IsInGround() {
        Ray ray = new Ray(this.gameObject.transform.position, new Vector3(0, -1, 0));
        RaycastHit RayForGround;
        if (Physics.Raycast(ray, out RayForGround))
        {
            Debug.DrawLine(ray.origin, RayForGround.point);//划出射线，在scene视图中能看到由摄像机发射出的射线
            GameObject gameObj = RayForGround.collider.gameObject;
            if (gameObj.name.StartsWith("Cube") == true)//当射线碰撞目标的name包含Cube，执行拾取操作
            {
                Debug.Log(gameObj.name);
            }
            float Distance = this.gameObject.transform.position.y - RayForGround.point.y;
            // Debug.Log(Distance);
            if (Distance < 0.51f * PlayerCapsule.height) { return false; }
            else { return true; }
           
        }
        return true;

        }

}
