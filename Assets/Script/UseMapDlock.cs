using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMapDlock : MonoBehaviour {
    Transform sd;
    public static MapDlock ThisUser;
    //public static Vector3 PlayerPositionInMapClock;
    //public static Vector3 PlayerPosition;
    //int X = 0;
    //int Z = 0;
    [SerializeField] GameObject PlaneGameobject;
    [SerializeField] GameObject PlayerRigidebody;
   
   


    // Use this for initialization
    void Start() {
        //PlayerPosition = new Vector3(0, 0, 0);
        //PlayerPositionInMapClock = new Vector3(0, 0, 0);
        ThisUser = new MapDlock("F:/MyGameSave/Map", "MapSave", PlaneGameobject);
        //  ThisUser.SaveAllMap("F:/MyGameSave/Map", "MapSave");
    }

    // Update is called once per frame
    void Update() {
        //这个隐藏内容是刷新PlayerPosition和PlayerPositionInMapClock位置的
        //PlayerPositionInMapClock = PlayerPositionInMapClock + new Vector3((int)PlayerRigidebody.transform.position.x, (int)PlayerRigidebody.transform.position.y, (int)PlayerRigidebody.transform.position.z) - PlayerPosition;
        //PlayerPosition = new Vector3((int)PlayerRigidebody.transform.position.x, (int)PlayerRigidebody.transform.position.y, (int)PlayerRigidebody.transform.position.z);

        //if (PlayerPositionInMapClock.x >= MapDlock.MapClockBigger)
        //{
        //    X++;
        //    PlayerPositionInMapClock.x -= MapDlock.MapClockBigger;
        //}
        //if (PlayerPositionInMapClock.z >= MapDlock.MapClockBigger)
        //{
        //    Z++;
        //    PlayerPositionInMapClock.z -= MapDlock.MapClockBigger;
        //}
        //if (PlayerPositionInMapClock.x < 0)
        //{
        //    X--;
        //    PlayerPositionInMapClock.x += MapDlock.MapClockBigger;
        //}
        //if (PlayerPositionInMapClock.z < 0)
        //{
        //    Z--;
        //    PlayerPositionInMapClock.z += MapDlock.MapClockBigger;
        //}

    }
    private void FixedUpdate()
    {

    }


}
