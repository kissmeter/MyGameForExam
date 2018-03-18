using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag72 : MonoBehaviour {
    [SerializeField]private GameObject TwoBagThing;
    private Vector3 ThisPosition;
    private float scrollamount;
    private float ScrollAmount{
        get{ return scrollamount; }
        set{
            Debug.Log("screenheight" + Screen.height);
            TwoBagThing.transform.position = new Vector3(0, 103 * 5.3f * value * Screen.height/1080f , 0) + ThisPosition;
        }
    }
	// Use this for initialization
	void Start () {
        ThisPosition = TwoBagThing.transform.position;
        Debug.Log(ThisPosition);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void WhenScroll(float X) {

        ScrollAmount = X;

    }
}
