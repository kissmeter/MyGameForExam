using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOfConsu
{
    private ProMode THISMODE;
    private int ConsuNum;
    private string ConsuName;
    private GameObject ConsuPrefab;
    //消耗品信息

    public DataOfConsu(int GetConsuNum,string GetConsuName, ProMode GetTHISMODE) {
        ConsuName = GetConsuName;
        ConsuNum = GetConsuNum;
        THISMODE = GetTHISMODE;
        
    }
    public int GetThisNumber() {
        return ConsuNum;

    }
}
