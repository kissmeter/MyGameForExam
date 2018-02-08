using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class TalkInfor : MonoBehaviour
{

    //是否需要在这里放一个枚举要素来判断是什么类型的对话
    public void TriggerATalk(GameObject NPC, GameObject Player) {
        //需要在这里检测是否为有效对话
        if (NPC.transform.position.x + NPC.transform.position.y + NPC.transform.position.z - Player.transform.position.x - Player.transform.position.y - Player.transform.position.z <= 7.6f) {

            Debug.Log("成功与" + NPC.name + "对话了");
        }
    }
    public void TalkWithSomeOne() {

        //几个对话失败的情况，NPC拒绝对话（包含入战问题）   //检测是否入战
        //好感度问题  //访问：好感度系统
        //如果不满足失败条件，那么进行对话
        //看看有没有任务（包含真正的任务、player主动聊天、突发状况三种）  访问：仔细列个表吧，挺复杂
        /*
         真正的任务：
         每一个NPC应该有关于他的所有任务，每个任务都应该有其触发条件，这个条件是不是可以被当作财富来存储。👈合理
         player主动聊天（类似楼上）:
         满足触发条件即可，类似楼上
         突发状况：
         NPC主动要求对话、满足一定条件后，系统主动要求NPC主动要求对话等，总之就是NPC主动要求对话，触发条件相同
         */




        //如果没有任务，根据当前好感度，触发基础对话内容                  访问：好感度系统  访问：对话内容

    }
    //需要写一个事件类，这里得到事件类，知道触发了哪一段的galgame
    public void TalkAloneJustLikeAGalGame()
    {




    }
          
}
