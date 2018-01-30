using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

    public class EnemyAll : MonoBehaviour
    {
        enum Dominate{



          }
        private Rigidbody Thisrigidbody;
        private int e_life;
        public void Start() {
        Thisrigidbody = this.gameObject.GetComponent<Rigidbody>();

         }
        public void BeAttack(Vector3 ForceFromSomeWhere,int ForceNumber,int AttackNumber,int SkillNum) {
            //ForceFromSomeWhere:力量来源 
            //ForceNumber:力量数值 
            //AttackNumber:攻击者的攻击力（算上所有攻击加成后）  
            //在这里根据力量方向和大小，技能类型来让他摇摆，让他血量减少,让他中buff  

        }

        void ToUseToTrash() {
            //使用协程摇摆  
            StartCoroutine(Enumerator_ToTrash());
            //使用完毕之后，使用协程倒下  
           
        }

        IEnumerator Enumerator_ToTrashDominate(Dominate ThisDominate)
        {
            //这是一个简单的控制，包含束缚眩晕等效果的特效 
            yield return 0;
        }
        IEnumerator Enumerator_ToTrashLong() {
            //和下面这个不同的是，这个是一个持续效果，持续效果是没有控制作用的 
            yield return 0;
        }
        IEnumerator Enumerator_ToTrash() {
            //在这里播放怪物在空中的动画 
            //在这里播放怪物受击的特效，音乐，浮动信息等 
            //确认这是让他摇摆的技能，开始摇摆(飞天移动等受力作用)  
            for (bool i = false; i == false;) {
                //i是是否落地，力量是否结束的意思，最终在需要他倒地并结束摇摆的时候宣布i=true,并宣布这个循环和协程结束 
                //在这里进行一些检测，确认i的值
                if (i)
                {
                    break;
                }
                yield return 0;
              
            }
            StartCoroutine(Enumerator_ToPutDown(5));
        }
        IEnumerator Enumerator_ToPutDown(int PutDownTime)
        {   //在这里让怪物的动画变为准备站起动画 
            //在这里播放怪物倒地站起的声音 
            //在这里播放怪物倒地的特效 
            //在这里让怪物因为倒地而限制一些功能 
            //对于一个怪物，他的倒下到站起的时间应该是固定或者既定的  
            yield return new WaitForSeconds(PutDownTime);
            //在这里播放怪物站起的动画 
            //在这里播放怪物站起的特效 
            //在这里解除某些因为倒地而限制的功能 
        }
        public void GetInforFromInternetToF5() {
            //解析这个信息并分析是哪种攻击方式，这个方法也可能是player的脚本组件告诉他的 

        }
        //public void ToTrash() {
         

        //}

        //public void ToPutDown() {
        //    //倒下
        //}
        
    }


