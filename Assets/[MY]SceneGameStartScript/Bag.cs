﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag {
    public static Bag bag;

    public static Bag SingleBag() {
           if (bag == null)
           {
               bag = new Bag();
           }
        return bag;
    }
    //对一个人的背包（仓库）而言，他拥有武器（编号），技能（编号，等级），消耗品（编号，数量），任务道具（编号，数量），任务（编号，对应任务道具）
    //一个人的武器应该有限制，技能不应该有限制（等级限制应该在技能信息中，点技能的时候用得到），任务道具的数量亦然，而任务的接取数量也应该是有限的
    /*武器
   
     
     
     
     */
    private int[] GunArray = new int[10 ];
    private int[] GunOnHandAndBack = new int[4];
    //当得到一把枪，是下面俩的中介
    //public void 添加一把枪
    //            替换一把枪
    //            扔掉一把枪
    //F捡到枪的交互实现之后，进入动画只是切换枪支的动画罢了。交互实现之后，立刻在这里实现逻辑，看是否继续这个交互还是返回？如何判断这次捡是成功的？失败的情况是什么？背包不能容纳但是要添加？            
    public void Gun_TransFromBagToHand(int BagGun_1, int HandGun_2)
    {
        int middle= GunArray[BagGun_1 - 1];
        GunArray[BagGun_1 - 1] = GunOnHandAndBack[HandGun_2 - 1];
        GunOnHandAndBack[HandGun_2 - 1] = middle;
    }
    public void Gun_TransFromHandToBag(int HandGun_1, int BagGun_2)
    {
        int middle = GunOnHandAndBack[HandGun_1 - 1];
        GunOnHandAndBack[HandGun_1 - 1] = GunArray[BagGun_2 - 1];
        GunArray[BagGun_2 - 1] = middle;

    }
    //有动画，交互立刻调用，调用立刻完成
    public void Gun_TransFromHandToHand(int HandGun_1, int HandGun_2)
    {
        int middle = GunOnHandAndBack[HandGun_1 - 1];
        GunOnHandAndBack[HandGun_1 - 1] = GunOnHandAndBack[HandGun_2 - 1];
        GunOnHandAndBack[HandGun_2 - 1] = middle;

    }
    //没有动画，交互立刻调用，调用立刻完成
    public void Gun_TransFromBagToBag(int BagGun_1, int BagGun_2)
    {
        int middle = GunArray[BagGun_1 - 1];
        GunArray[BagGun_1 - 1] = GunArray[BagGun_2 - 1];
        GunArray[BagGun_2 - 1] = middle;
    }
    public void Gun_PutOutOneFromBag(int IsWhat)
    {
        GunArray[IsWhat - 1] = 999999;
    }
    public void Gun_PutOutOneFromHand(int IsWhat) {

        GunOnHandAndBack[IsWhat - 1] = 999999;
    }
    //双手为空的时候捡枪会调用这个 ，捡到立刻调用，以上所有就算有动画，动画被打断也捡到
    public void Gun_GetOneToHand(int IsWhat,DataOfGun ThisGun)
    {
        GunOnHandAndBack[IsWhat - 1] = ThisGun.GetThisNumber();
    }
    //惟一一个要检查是否有空项的，在捡拾的地方询问这里是否背包中还有空间,然后才调用下面这个
    public bool Gun_IsBagHasRoom() {
        for (int i = 0; i < 10; i++)
        {
            if (GunArray[i]==999999|| GunArray[i]<=0) {

                return true;
            }
            
        }

        return false;
    }
    //刷新专用，返回dataofgun类的所有现持有信息 
    public void ToGetGunListNumber(out List<DataOfGun> GunListNumber, out List<int> GunLast) {
        List<int> ii=new List<int>();
        for (int i = 0; i < 14; i++)
        {
            ii.Add(GunArray[i]- 100000);
            Debug.Log("i=" + i + "AndIts" + GunArray[i]);
        }
       
        //for (int i = 0; i < 4; i++)
        //{
        //    ii.Add(GunOnHandAndBack[i]-100000);
        //}
        GunListNumber = OneGunProperty.GetGunProperty().GetGunByNumbers(ii);
        //先last2
        GunLast = new List<int>() { 2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    }
    public void Gun_GetOneToBag(DataOfGun ThisGun)
    {//wwwwwwwww!!!!!!!!
        for (int i = 0; i < 10; i++)
        {
            if (GunArray[i] == 999999 || GunArray[i] <= 0)
            {
                GunArray[i] = ThisGun.GetThisNumber();
                return;
            }

        }
        //如果能够进行到这里就太可怕了！！！！！！！！！！！！！！！！！！！！！！！！！！说明游戏崩盘了。
    }

    /*技能
     
     */
    private List<int> SkillArray = new List<int>();




    /*消耗品
     加上技能和消耗品和任务道具一共背包有60格
     
     */
    private int[] ConsuArray = new int[50];
    //道具的拥有数量
    private int[] ConsuCount = new int[50];
    //检测第一个空背包是什么
    private int CountHaveEmpty() {
       
        for (int i = 0; i < ConsuCount.Length; i++)
        {
            if(ConsuCount[i] == 0){
                return i;
            }
        }
        return 999999;


    }
    //添加一个道具，需要检索道具库有没有这个道具有的话就add，没有的话如果包裹没有满就添加，满了就返回
    public void AddAConsu(DataOfConsu ConsuWillAdd,int consunumber) {
        for (int i = 0; i < ConsuArray.Length; i++)
        {
            if (ConsuArray[i] == ConsuWillAdd.GetThisNumber()) {
                ConsuCount[i] += consunumber;
                return;
            }

        }
        //如果进行到这里，那就是没有这个道具
        int j = CountHaveEmpty();
        if (j != 999999)
        {
            ConsuArray[j] = ConsuWillAdd.GetThisNumber();
            ConsuCount[j] = consunumber;

            return;
        }
        else {
        

        }
    }
    
    
    
    /*任务道具
     
     
     */
    /*任务
     
     
     
     */
 
}