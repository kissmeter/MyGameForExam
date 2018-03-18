using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFindPlayer : MonoBehaviour {
    [SerializeField]private float Radius;
    [SerializeField][Range(0,10)]private float TimeSpace;
    [SerializeField]SingleMode_1 ThisGameMode_1_Manager;
    [SerializeField]private float EffectByFog; 
    private float LeftTime;
	// Use this for initialization
	void Start () {
        if (TimeSpace == 0) {
            TimeSpace = 5;
        }
        LeftTime = TimeSpace;
   
        BoxCollider ThisCollider = this.gameObject.AddComponent<BoxCollider>();
        ThisCollider.isTrigger = true;
        if (Radius == 0)
        {
            ThisCollider.size = new Vector3(50, 50, 50);

        }
        else {

            ThisCollider.size = new Vector3(Radius, Radius, Radius);

        }

	}
    private void FixedUpdate()
    {
       

    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {

            LeftTime -= 0.02f;

            if (LeftTime <= 0)
            {
                //在这里计算距离和浓度
                ThisGameMode_1_Manager.GetEventInFog(2, 4);
                LeftTime = TimeSpace;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            LeftTime = TimeSpace;
           //chong zhi


        }
    }
}
