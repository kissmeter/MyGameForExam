using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToMap : MonoBehaviour {
    [SerializeField] Vector3 PlayerPosition;
    [SerializeField] Vector3 PlayerPositionInMapClock;
    int X = 0;
    int Z = 0;
    
    // Use this for initialization
    void Start () {

<<<<<<< HEAD:Assets/Script/TriggerToMap.cs
        PlayerPositionInMapClock = new Vector3(0, 0, 0);
=======
        PlayerPositionInMapClock = new Vector3(50, 0, 50);
>>>>>>> 43cab55d71a13c9beb2e07f150fa6d91c16429fa:Assets/ScriptInSceneGameForEditor/TriggerToMap.cs
        PlayerPosition = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
    }

    // Update is called once per frame
    public Vector3 positions() {
        return new Vector3(0,0,0);
    }
	void Update () {
        PlayerPositionInMapClock = PlayerPositionInMapClock + new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z) - PlayerPosition;
        PlayerPosition = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);

        if (PlayerPositionInMapClock.x >= MapDlock.MapClockBigger)
        {
            X++;
            PlayerPositionInMapClock.x -= MapDlock.MapClockBigger;
        }
        if (PlayerPositionInMapClock.z >= MapDlock.MapClockBigger)
        {
            Z++;
            PlayerPositionInMapClock.z -= MapDlock.MapClockBigger;
        }
        if (PlayerPositionInMapClock.x < 0)
        {
            X--;
            PlayerPositionInMapClock.x += MapDlock.MapClockBigger;
        }
        if (PlayerPositionInMapClock.z < 0)
        {
            Z--;
            PlayerPositionInMapClock.z += MapDlock.MapClockBigger;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
      
        Debug.Log("撞到东西辣" + (int)this.PlayerPositionInMapClock.x + "" + (int)this.PlayerPositionInMapClock.z);
        int mapbig = MapDlock.MapClockBigger;
        //int x = (int)UseMapDlock.PlayerPositionInMapClock.x;
        //int z = (int)UseMapDlock.PlayerPositionInMapClock.z;
        int x = (int)this.PlayerPosition.x;
        int z = (int)this.PlayerPosition.z;
        
        if (this.PlayerPositionInMapClock.x <= 0.25* mapbig) {
            Debug.Log("x-1");
            UseMapDlock.ThisUser.Flash(x - mapbig, z);
            UseMapDlock.ThisUser.Flash(x - mapbig, z - mapbig);
            UseMapDlock.ThisUser.Flash(x - mapbig, z + mapbig);

        }
      
        if (this.PlayerPositionInMapClock.x >= 0.75 * mapbig) {
            Debug.Log("x+1");
            UseMapDlock.ThisUser.Flash(x + mapbig, z);
            UseMapDlock.ThisUser.Flash(x + mapbig, z - mapbig);
            UseMapDlock.ThisUser.Flash(x + mapbig, z + mapbig);
        }
        if (this.PlayerPositionInMapClock.z <= 0.25 * mapbig) {
            Debug.Log("z-1");
            UseMapDlock.ThisUser.Flash(x , z - mapbig);
            UseMapDlock.ThisUser.Flash(x - mapbig, z - mapbig);
            UseMapDlock.ThisUser.Flash(x + mapbig, z - mapbig);
        }
        if (this.PlayerPositionInMapClock.z >= 0.75 * mapbig) {
            Debug.Log("z+1");
            UseMapDlock.ThisUser.Flash(x , z + mapbig);
            UseMapDlock.ThisUser.Flash(x - mapbig, z + mapbig);
            UseMapDlock.ThisUser.Flash(x + mapbig, z + mapbig);
        }
        //UseMapDlock.ThisUser.MakeItOutOfMeshFarAwayOfMe((int)UseMapDlock.PlayerPositionInMapClock.x, (int)UseMapDlock.PlayerPositionInMapClock.z);
        //UseMapDlock.ThisUser.MakeItGetMeshBehindOfMe((int)UseMapDlock.PlayerPositionInMapClock.x, (int)UseMapDlock.PlayerPositionInMapClock.z);
        //Debug.Log((int)UseMapDlock.PlayerPositionInMapClock.x + "y:" + (int)UseMapDlock.PlayerPositionInMapClock.z);
        
        //Debug.Log(collider.gameObject.transform.name);
        
    }
}
