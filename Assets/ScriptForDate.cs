using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptForDate : MonoBehaviour {
    [SerializeField]InputField IDField;
    [SerializeField]InputField PasswordField;
    [SerializeField]GameObject AnothorPlane;
    [SerializeField] GameObject ThisPlane;
    // Use this for initialization
    void Start () {
        AnothorPlane.SetActive(false);
        ThisPlane.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //如果键入了登入，IDField.text是ID键入的内容，PasswordField.text是密码键入的内容 
    public void WhenPutLogIn() {
        Debug.Log("键入了登录!id="+ IDField.text+""+ PasswordField.text);

    }
    public void GetFromServer() { }
    public void WhenPutRegister() {
        Debug.Log("键入了注册!");
        
        AnothorPlane.SetActive(true);
        ThisPlane.SetActive(false);
    }
}
