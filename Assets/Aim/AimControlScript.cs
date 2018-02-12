using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AimControlScript : MonoBehaviour {
    [SerializeField]Image[] ThisImage=new Image[4];
    [SerializeField] Vector3[] ImagePosition;
    //认定 0 上 1 左 2 下 3 右
	// Use this for initialization
	void Start () {
        ImagePosition = new Vector3[ThisImage.Length];
        for (int i = 0; i < ThisImage.Length; i++)
        {
            ImagePosition[i] = ThisImage[i].transform.position;
        }
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void IfShotAtOnece() {
        //访问现在的握枪能力，以及当前枪种的力量 定为A 和 B
        float A, B;
        A = 1;
        B = 10;
        StopAllCoroutines();
        StartCoroutine(StartToTrans(A, B));

    }
    IEnumerator StartToTrans(float A,float B) {

        for (int i = 0; i < B/A; i++)
        {
            ThisImage[0].transform.Translate(0, 1 / A, 0);
            ThisImage[1].transform.Translate(-1 / A, 0, 0);
            ThisImage[2].transform.Translate(0, -1 / A, 0);
            ThisImage[3].transform.Translate(1 / A, 0, 0);
            yield return null;
        }
        for (int i = 0; i < ThisImage.Length; i++)
        {
            ThisImage[i].transform.position=ImagePosition[i];
        }
    }
}
