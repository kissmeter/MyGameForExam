using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneGunProperty 
{   //这里面储存的是所有的武器 
        private ProMode ThisGunMode;
        private List<GameObject> GunGameObjectList = new List<GameObject>(); 
        private static OneGunProperty GunProperty = null;
        private List<DataOfGun> GunNum = new List<DataOfGun>();
        private DataOfGun GunNum_01;
        private OneGunProperty()
        {
       
         //道具包含任务，背包元素，技能三种,而背包元素包含枪，消耗品和任务道具    
         //================================== 
         ThisGunMode = new ProMode(ProMode.PROMode.GUN);
         //这是一个示例，这个list要变成dictionary，而且是储存了所有道具信息的  
         GunNum.Add(new DataOfGun(100001, "MP5", Resources.Load<GameObject>("New Prefab"), 1, 1, 1, ThisGunMode));
         GunNum.Add(new DataOfGun(100002, "MP6", Resources.Load<GameObject>("New Prefab"), 2, 2, 2, ThisGunMode));
         GunNum.Add(new DataOfGun(100003, "MP7", Resources.Load<GameObject>("New Prefab"), 3, 3, 3, ThisGunMode));
         GunNum.Add(new DataOfGun(100004, "MP8", Resources.Load<GameObject>("New Prefab"), 4, 4, 4, ThisGunMode));
         GunNum.Add(new DataOfGun(100005, "MP9", Resources.Load<GameObject>("New Prefab"), 5, 5, 5, ThisGunMode));
         GunNum.Add(new DataOfGun(100006, "MP5", Resources.Load<GameObject>("New Prefab"), 1, 1, 1, ThisGunMode));
         GunNum.Add(new DataOfGun(100007, "MP6", Resources.Load<GameObject>("New Prefab"), 2, 2, 2, ThisGunMode));
         GunNum.Add(new DataOfGun(100008, "MP7", Resources.Load<GameObject>("New Prefab"), 3, 3, 3, ThisGunMode));
         GunNum.Add(new DataOfGun(100009, "MP8", Resources.Load<GameObject>("New Prefab"), 4, 4, 4, ThisGunMode));
         GunNum.Add(new DataOfGun(100010, "MP9", Resources.Load<GameObject>("New Prefab"), 5, 5, 5, ThisGunMode));
         GunNum.Add(new DataOfGun(100011, "MP5", Resources.Load<GameObject>("New Prefab"), 1, 1, 1, ThisGunMode));
         GunNum.Add(new DataOfGun(100012, "MP6", Resources.Load<GameObject>("New Prefab"), 2, 2, 2, ThisGunMode));
         GunNum.Add(new DataOfGun(100013, "MP7", Resources.Load<GameObject>("New Prefab"), 3, 3, 3, ThisGunMode));
         GunNum.Add(new DataOfGun(100014, "MP8", Resources.Load<GameObject>("New Prefab"), 4, 4, 4, ThisGunMode));
         GunNum.Add(new DataOfGun(100015, "MP9", Resources.Load<GameObject>("New Prefab"), 5, 5, 5, ThisGunMode));

    }

    public static OneGunProperty GetGunProperty()
        {
            if (GunProperty == null)
            {
            GunProperty = new OneGunProperty();
            }
            return GunProperty;
        }
   
        public ProMode.PROMode Skill_Mode()
        {
            return GunProperty.ThisGunMode.THISMODE;
        }

        public DataOfGun GetGunByNumber(int I)
        {

        return GunNum[I-100000];

        }
        public System.Collections.Generic.List<DataOfGun> GetGunByNumbers(System.Collections.Generic.List<int> NumberINeed)
        {

        List<DataOfGun> GunNumIFind = new List<DataOfGun>();
        for (int i = 0; i < NumberINeed.Count; i++)
        {
            try
            {
                GunNumIFind.Add(GunNum[NumberINeed[i]-2]);
            }
            catch {
               //看下面 
               // throw new Exception("我骚你妈，给的list中的数值，列表里压根没这个数 ");
            }
           
        }
        foreach (var Hi in GunNumIFind)
        {
            Debug.Log(Hi.GetThisNumber());
        }
        return GunNumIFind;

        }
        public DataOfGun GiveOneGunInfor(int NumberINeed) {

         return GunNum[NumberINeed];
       }
    }
