using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptForDate : MonoBehaviour {
    [SerializeField]InputField IDField;
    [SerializeField]InputField PasswordField;
    [SerializeField]GameObject AnothorPlane;
    [SerializeField]GameObject ThisPlane;
    private string url = "http://localhost:9527/UpLoadServer/servlet/UserLogin";
    //private string url ="";
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
        string parameter = "";
        parameter += "UserName=" + IDField.text + "&";
        parameter += "PassWord=" + PasswordField.text;
        StartCoroutine(login(parameter));
        Debug.Log("键入了登录!id="+ IDField.text+""+ PasswordField.text);

    }

    private IEnumerator login(string path)
    {
        WWW www = new WWW(path);
        yield return www;
        //如果发生错误，打印这个错误 
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            //如果服务器返回的是true 
            if (www.text.Equals("true"))
            {
                //登陆成功 
                print("Login Success!!!");
              //  Application.LoadLevel("UpLoadFile");
            }
            else
            {
                //否则登录失败
                print("Login Fail...");
            }
        }
    }



    public void GetFromServer() { }
    public void WhenPutRegister() {
        Debug.Log("键入了注册!");
        
        AnothorPlane.SetActive(true);
        ThisPlane.SetActive(false);
    }
}
