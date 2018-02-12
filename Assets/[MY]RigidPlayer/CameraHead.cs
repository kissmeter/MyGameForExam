using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class CameraHead : MonoBehaviour {
    Camera Head;
    Vector3 OldVRotationEuler;
    //=================

    //================
 
    // Use this for initialization
    void Start () {
      //  CubeTrans = GameObject.Find("Sphere").transform;
       
        Head =this.gameObject.GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //  this.transform.position = CubeTrans.position;
       // MouseForListen();
        RotateToListenMouse();
      //  Debug.Log("X="+MouseForListen().x+"Y="+ MouseForListen().y);
    }

    private Vector3 MouseForListen() {

            float y = Input.GetAxis("Mouse X");
            float x = Input.GetAxis("Mouse Y");
           // Debug.Log("X=" + x + "Y=" + y);
            OldVRotationEuler.x -= 4 * x;
            OldVRotationEuler.y += 4 * y;
            return OldVRotationEuler;
    }
    private void RotateToListenMouse() {
        //处于选择模式，编辑模式，警告模式，操作模式的时候不能接受旋转
        this.transform.eulerAngles = MouseForListen();
        this.transform.parent.eulerAngles = new Vector3(0, MouseForListen().y, 0);
        //性能标记，这样可以减少bug可能性但是每帧都要赋值一次，最好的办法是进入这一模式的时候赋值 
        //Cursor.visible = false;


    }
}
