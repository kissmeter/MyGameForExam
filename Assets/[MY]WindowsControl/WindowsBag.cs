using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsBag : MonoBehaviour {
    [SerializeField] GameObject[] FourteenButton;
    [SerializeField] GameObject[] GunHaveSetActive;
    List<DataOfGun> DataOfGunList;
    List<int> GunLast;
    int I;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(1111111);
      //  Debug.Log(Input.GetKeyDown(KeyCode.P));
        if (Input.GetKeyDown(KeyCode.P)) {
            sssss();

        }
	}
    //++++++++++++++++++++++++++++++++++++++++
    //这之间是对bag的调用了 
    public void sssss() {

        Bag.SingleBag().Gun_TransFromBagToBag(I+5, I+7);
        I++;
        refresh();

    }
    public void refresh() {
        //get all information in bag,and refresh it!
        Bag.SingleBag().ToGetGunListNumber(out DataOfGunList, out GunLast);
        for (int i = 0; i < DataOfGunList.Count; i++)
        {
         //   Debug.Log(DataOfGunList[i].GetThisNumber());
        }
     
        //
        for (int i = 0; i < 14; i++)
        {
            int ThisNumber = DataOfGunList[i].GetThisNumber();
            //如果比较大于10w小于20w，则比较消耗性能了，不过如果到时候出现bug，那就只能这样比较了
            if (ThisNumber != 999999 && ThisNumber != 0)
            {
                //在这个gameobject上的位置生成一个而非别的,不，并非生成，而是所有gun都是预设好的，在某个位置罢了，他只负责 调用而已。
                Debug.Log(ThisNumber - 100001);
                GunHaveSetActive[ThisNumber - 100001].transform.position = FourteenButton[i].transform.position;
            

            }
     
        }

    }
    
    //========================================
}
