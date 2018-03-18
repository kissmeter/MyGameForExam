using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOfGun {
    private ProMode THISMODE;
    private int GunNum;
    private string GunName;
    private GameObject GunPrefab;
    private float GunShotSpeed;
    private int GunRoom;
    private float TimeOfFilling; 


    public DataOfGun(int GunNum,string GunName, GameObject GunPrefab, float GunShotSpeed, int GunRoom, float TimeOfFilling) {

        this.GunNum    = GunNum;
        this.GunPrefab = GunPrefab;
        this.GunName   = GunName;
        this.GunShotSpeed = GunShotSpeed;
        this.GunRoom = GunRoom;
        this.TimeOfFilling = TimeOfFilling;
     
        //10000,MPPPP,null,0.5,5,3,
    }
    public float GiveGunShotSpeed ()
    {

        return GunShotSpeed;
    }
    public int GiveGunRoom()
    {

        return GunRoom;
    }
    public float GiveTimeOfFilling()
    {

        return TimeOfFilling;
    }
    public int GetThisNumber()
    {

        return GunNum;
    }
}
