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


    public DataOfGun(int GunNum,string GunName, GameObject GunPrefab, float GunShotSpeed, int GunRoom, float TimeOfFilling, ProMode THISMODE) {

        this.GunNum    = GunNum;
        this.GunPrefab = GunPrefab;
        this.GunName   = GunName;
        this.GunShotSpeed = GunShotSpeed;
        this.GunRoom = GunRoom;
        this.TimeOfFilling = TimeOfFilling;
        this.THISMODE = THISMODE;
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
