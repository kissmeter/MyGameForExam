using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_1 : MonoBehaviour {

    //这是关卡控制系统，开放地图关卡控制
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void StartGameMode_1() {
        //1 2 3是单机 
        //step_1  访问他要攻略的是什么副本，是本地副本还是联机副本，本地副本就是加载，联机副本就是下载再加载，加载完毕之后step_1完成
        //step_2  访问玩家当前状态，看是否可以进入游戏，是否在另一个关卡中等等（应该没问题吧）
        //step_3  如果可以进入游戏，直接将场景实例化，进行初始化地图
        //step_4  根据玩家的身份，确定玩家进入地图时候的权限
        //如果处于联机状态，将会开启访问对方的协程，询问是否准备完成，这个协程是联机方法StartGameOnServer_1，而这种情况下将不会调用startgamemode_1里的内容
 
        SceneManager.LoadScene("GameMode_1");
    }
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
    //IEnumerator StartGameOnServer_1() {

    //    WWW www=new WWW();
    //    yield return www;
    //}
    //IEnumerator StartGameOnClient_1() {


    //}
    void PauseGameMode_1() { }

    void EndGameMode_1()   { }

    void VictoryGameMode_1() {
        //同步胜利信息
        //加载胜利页面
        //给出不需要点确定就能退出当前副本的权限，当前如果调用LeaveGameWhenGameMode_1也可以立刻退出 借用bool victory
        //切换回场景或者释放内存


    }
    void LeaveGameWhenGameMode_1() {
        //询问是否中途退出关卡
        //退出关卡，加载主场景或者清理当前内存
    }
    void FailedGameMode_1() { }
   //void WhenStartGameMode_1() { }

    //void WhenEndGameMode_1() { }

}
