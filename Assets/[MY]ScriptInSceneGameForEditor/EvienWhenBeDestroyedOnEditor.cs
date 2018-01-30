using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvienWhenBeDestroyedOnEditor : MonoBehaviour {
    private int BIX;
    private int BIY;
    private int SMX;
    private int SMY;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public EvienWhenBeDestroyedOnEditor(int BigMapListNumberX, int BigMapListNumberY, int SmallMapListNumberX, int SmallMapListNumberY) {
        BIX = BigMapListNumberX;
        BIY = BigMapListNumberY;
        SMX = SmallMapListNumberX;
        SMY = SmallMapListNumberY;
    }


    public void BeCreate(int BigMapListNumberX, int BigMapListNumberY, int SmallMapListNumberX, int SmallMapListNumberY) {
        BIX = BigMapListNumberX;
        BIY = BigMapListNumberY;
        SMX = SmallMapListNumberX;
        SMY = SmallMapListNumberY;

    }
    public void BeDes() {
        UseMapDlock.ThisUser.WhenDestoryAMapBlock(BIX,BIY,SMX,SMY);
    }
}
