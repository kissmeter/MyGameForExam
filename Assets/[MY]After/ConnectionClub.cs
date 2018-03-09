using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionClub {
    //里面应该储存有当前队伍和连接的全部信息，房间应该以端口为核心。这个端口储存在服务器中。
    private int HousePost;

    PlayerInfor[] ConnectionPlayer;
    public ConnectionClub(int housepost) {

     ConnectionPlayer=new PlayerInfor[4];
     HousePost = housepost;

    }
    public void AddOnePlayer(PlayerInfor AddPlayer) {
        for (int i = 0; i < 4; i++)
        {
            if (ConnectionPlayer[ i ] == null)
            {
                ConnectionPlayer[0] = AddPlayer;
                return;
            }

        }
  
    }
    public void LeaveOnePlayer(PlayerInfor LeavePlayer) {

        for (int i = 0; i < 4; i++)
        {
            if (LeavePlayer.PlayerNumber == ConnectionPlayer[i].PlayerNumber) {

                ConnectionPlayer[i] = null;

            }


        }

    }
  
}
