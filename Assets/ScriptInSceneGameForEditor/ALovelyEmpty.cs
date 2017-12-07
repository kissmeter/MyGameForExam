using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALovelyEmpty : MonoBehaviour {
    private Vector3 HitPosition; 
	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HitButton1() {
        UseMapDlock.ThisUser.ControlAPrefabNameOfBlock(new Vector2(HitPosition.x, HitPosition.z),new Vector3((int)(HitPosition.x+50)/100,0, (int)HitPosition.z + 50) / 100,"startname","cuber");
        this.gameObject.SetActive(false);
    }
    public void HitButton2() {
        this.gameObject.SetActive(false);
    }
    public void HitPoint(RaycastHit hitInfo) {
        this.gameObject.SetActive(true);
    Debug.Log("改变了我的位置哦" + hitInfo.point);
        HitPosition = new Vector3((int)hitInfo.point.x,0,(int)hitInfo.point.z);
    }
}
