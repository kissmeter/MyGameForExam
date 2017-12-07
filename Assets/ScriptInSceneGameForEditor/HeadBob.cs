using System;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class HeadBob : MonoBehaviour
    {
        //=================================
        [SerializeField] GameObject PanelOfTwoButton;
        //===================================
        public Camera Camera;
        public CurveControlledBob motionBob = new CurveControlledBob();
        public LerpControlledBob jumpAndLandingBob = new LerpControlledBob();
        public RigidbodyFirstPersonController rigidbodyFirstPersonController;
        public float StrideInterval;
        [Range(0f, 1f)] public float RunningStrideLengthen;

       // private CameraRefocus m_CameraRefocus;
        private bool m_PreviouslyGrounded;
        private Vector3 m_OriginalCameraPosition;


        private void Start()
        {
            motionBob.Setup(Camera, StrideInterval);
            m_OriginalCameraPosition = Camera.transform.localPosition;
       //     m_CameraRefocus = new CameraRefocus(Camera, transform.root.transform, Camera.transform.localPosition);
        }

     
        private void Update()
        {//这些是要给摄像机（VR的手柄）的 
               if(Input.GetKeyDown(KeyCode.H))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出到点击坐标的射线
                            RaycastHit hitInfo;
                            if (Physics.Raycast(ray, out hitInfo))
                                 {
                                    Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到
                                     GameObject gameObj = hitInfo.collider.gameObject;
                                     Debug.Log("click object name is " + gameObj.name+""+ hitInfo.point);
                    if (gameObj.tag == "MapPlane")
                    {
                        //如果是游玩，则没反应，如果是编辑，则弹出UI，释放什么环境加进去  
                        //1，游玩：
                        //2.1，编辑：Panel.SetActive(true);
                        //不再接受任何别的点击事件
                        print("点击了地面哦！");
                        PanelOfTwoButton.GetComponent<ALovelyEmpty>().HitPoint(hitInfo);
                        //  PanelOfTwoButton.SetActive(true);
                        //2.2，编辑：
                    }
                    else if (gameObj.tag == "Zombe")
                    {
                        //如果是游玩，则射击，如果是编辑，则摧毁 
                        //1，游玩：Shot(this.Attack,this.Force);
                        //2.1，编辑：DestroyImmediate(this.gameObject);
                        
                        //2.2，编辑：
                    }
                    else if (gameObj.tag == "BigEvien") {
                        //如果是游玩，则没反应，如果是编辑，则摧毁
                        //1，游玩：
                        //2.1，编辑：DestroyImmediate(this.gameObject);

                        //2.2，编辑：
                    }
                }
                         }
            //  m_CameraRefocus.GetFocusPoint();
            Vector3 newCameraPosition;
            if (rigidbodyFirstPersonController.Velocity.magnitude > 0 && rigidbodyFirstPersonController.Grounded)
            {
                Camera.transform.localPosition = motionBob.DoHeadBob(rigidbodyFirstPersonController.Velocity.magnitude*(rigidbodyFirstPersonController.Running ? RunningStrideLengthen : 1f));
                newCameraPosition = Camera.transform.localPosition;
                newCameraPosition.y = Camera.transform.localPosition.y - jumpAndLandingBob.Offset();
            }
            else
            {
                newCameraPosition = Camera.transform.localPosition;
                newCameraPosition.y = m_OriginalCameraPosition.y - jumpAndLandingBob.Offset();
            }
            Camera.transform.localPosition = newCameraPosition;

            if (!m_PreviouslyGrounded && rigidbodyFirstPersonController.Grounded)
            {
                StartCoroutine(jumpAndLandingBob.DoBobCycle());
            }

            m_PreviouslyGrounded = rigidbodyFirstPersonController.Grounded;
          //  m_CameraRefocus.SetFocusPoint();
        }
    }
}
