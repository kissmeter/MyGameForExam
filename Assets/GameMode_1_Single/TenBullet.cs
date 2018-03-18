using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenBullet : MonoBehaviour {
    [SerializeField]List<GameObject> BulletList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TransBullet(int BulletCount) {
        if (BulletCount <= 0)
        {
            //全部消失
            for (int i = 0; i < 10; i++)
            {
                BulletList[i].SetActive(false);
            }
        }
        else if (BulletCount >= 10)
        {
            //十个全部显形
            for (int i = 0; i < 10; i++)
            {
                BulletList[i].SetActive(true);
            }
        }
        else {
           
            for (int i = 0; i < BulletCount; i++)
            {
                BulletList[i].SetActive(true);
            }
            for (int i = 0; i < 10 - BulletCount; i++)
            {
                BulletList[BulletCount + i].SetActive(false);
            }
            //根据数字确定从0开始显形几个

        }


    }
}
