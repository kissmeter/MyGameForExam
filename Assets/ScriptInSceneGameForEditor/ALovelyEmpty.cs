using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALovelyEmpty : MonoBehaviour {
    private Vector3 HitPosition;
    private Vector3 HitBigPosition;
    [SerializeField] GameObject Cube;
    [SerializeField] GameObject CapS;
	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HitButton1() {
        UseMapDlock.ThisUser.CreateWhenPlayerHitButton((int)(HitBigPosition.x+5/10), (int)(HitBigPosition.z + 5 / 10), (int)HitPosition.x, (int)HitPosition.z, Cube);
        this.gameObject.SetActive(false);
    }
    public void HitButton2() {
        this.gameObject.SetActive(false);
    }
    public void HitPoint(RaycastHit hitInfo) {
        this.gameObject.SetActive(true);
        Debug.Log("改变了我的位置哦" + hitInfo.point);
        HitPosition = new Vector3(BringASmallClock(hitInfo.point.x),0, BringASmallClock(hitInfo.point.z));
        HitBigPosition = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
    }
    private int BringASmallClock(float Getal) {
        if (Getal >= 0)
        {
            return (int)(Getal - Getal * ((int)Getal / 100));
        }
        else {
            return (int)(100+Getal-Getal * ((int)Getal / 100));
        }
    }
}
