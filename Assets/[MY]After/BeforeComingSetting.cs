using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeComingSetting : MonoBehaviour {

    //游戏模式
    private bool HaveKeepAtOnece;
    public int GameMode;
    public void TransGameMode (int i){

        GameMode = i;

    }

    //初始装备 武器2 道具4
    public DataOfGun[] GunWhenStart;
    public DataOfConsu[] ConsuWhenStart;

    public void SetGun(int i,DataOfGun j) {

        GunWhenStart[i] = j;

    }
    public void SetConsu(int i, DataOfConsu j)
    {
        ConsuWhenStart[i] = j;

    }
    //玩家设置
    bool Set_1;
    //这个的初始化和保存设置是json，一共是三个设置 
    bool Set_2;
    bool Set_3;
    //是否联机
    bool OnConnectting;
    //联机对象
    //bool Command_2 have someone here?
    //int Command_2;
    //connection信息
    ConnectionClub ThisConnectHouseInfor;


	// Use this for initialization
	void Start () {

        GunWhenStart = new DataOfGun[4];
        ConsuWhenStart = new DataOfConsu[4];
        OnConnectting = false;
        GameMode = 0;
        HaveKeepAtOnece = false;
        ThisConnectHouseInfor = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
