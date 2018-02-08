using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSomeUIAndOtherWin : MonoBehaviour {

   
    [SerializeField] List<GameObject> EveryWindows=new List<GameObject>();





	// Use this for initialization
	void Start () {

        EveryWindows[0].SetActive(false);
        EveryWindows[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            for (int i = 0; i < EveryWindows.Count; i++)
            {
                if (EveryWindows[i].activeSelf) {
                    EveryWindows[i].SetActive(false);
                    return;
                }
            }
          


        }
	}
    public void OpenBagWins() {

        EveryWindows[0].SetActive(true);

    }

}
