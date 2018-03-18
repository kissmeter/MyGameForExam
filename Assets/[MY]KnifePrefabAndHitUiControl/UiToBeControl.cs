using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiToBeControl : MonoBehaviour {
    static Transform canvas;

    private void OnEnable()
    {
        if (canvas == null) {
         //   canvas = GameObject.Find("WorldPoint").transform;
        }
        this.transform.parent = canvas;
        //开始你的表演
    }
    public void transText(string NewText,Color NewColor) {

        this.GetComponent<Text>().text = NewText;
        this.GetComponent<Text>().color = NewColor;
    }
    private void OnDisable()
    {
        //结束你的表演
    }
}
