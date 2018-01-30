using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlKnifeAndUi  {
    ParticleSystem Knife;
    GameObject HitUi;
    // List<KnifeToBeControl> KnifeProjectList=new List<KnifeToBeControl>();
    // List<UiToBeControl> UiProjectList=new List<UiToBeControl>();
    List<ParticleSystem> KnifeProjectList = new List<ParticleSystem>();
    List<UiToBeControl> UiProjectList = new List<UiToBeControl>();
    int i = 0;
    // Use this for initialization
    public static ControlKnifeAndUi OneControlKU;
    public static ControlKnifeAndUi GetControlKU()
    {
        if (OneControlKU == null)
        {
            OneControlKU = new ControlKnifeAndUi();
        }
        return OneControlKU;
    }
    public ControlKnifeAndUi() {
        //加载刀光特效和UI
        Knife = Resources.Load<ParticleSystem>("Knife");
        HitUi = Resources.Load<GameObject>("HitUi");
        for (int i = 0; i < 100; i++)
        {
            KnifeProjectList.Add(UnityEngine.MonoBehaviour.Instantiate(Knife));
            KnifeProjectList[i].gameObject.SetActive(false);
            UiProjectList.Add(UnityEngine.MonoBehaviour.Instantiate(HitUi).GetComponent<UiToBeControl>());
            UiProjectList[i].gameObject.SetActive(false);
        }
      //  UiProjectList[0].GiveCanvas(GameObject.Find("WorldPoint").transform);

    }
 //   void Start () {
 //       //可以初始化加载，也可以在start加载，未来希望能改成初始化加载
    
 

	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
   public int TheNext() {
        i++;
        if (i >= 100) {
            i = 0;
        }
        return i-1;
    }   
    public IEnumerator ParticleCorat(Vector3 Position,int i)
    {
        Debug.Log("开始了粒子协程，位置是"+ Position + ",序号是"+i);
        ParticleSystem ThisParticleSystem= KnifeProjectList[i];
        ThisParticleSystem.gameObject.SetActive(true);
        ThisParticleSystem.transform.position = Position;
        ThisParticleSystem.Play();
        yield return new WaitForSeconds(0.1f);
        Debug.Log("关闭了粒子协程序号是" + i);
        ThisParticleSystem.Stop();


    }
    public IEnumerator HitUiOnSky(Vector3 Position,int i,string attack,Color ThisColor) {
        Debug.Log("开始了UI协程，位置是" + Position + ",序号是" + i);
        UiToBeControl ThisUI = UiProjectList[i];
        ThisUI.gameObject.SetActive(true);
        ThisUI.gameObject.transform.position = Position;
        ThisUI.transText(attack,ThisColor);
      
        yield return new WaitForSeconds(1.5f);
        ThisUI.gameObject.SetActive(false);
    }
}
