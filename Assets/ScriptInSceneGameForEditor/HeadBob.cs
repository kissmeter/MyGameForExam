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
        {//��Щ��Ҫ���������VR���ֱ����� 
               if(Input.GetKeyDown(KeyCode.H))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//�������������������������
                            RaycastHit hitInfo;
                            if (Physics.Raycast(ray, out hitInfo))
                                 {
                                    Debug.DrawLine(ray.origin, hitInfo.point);//�������ߣ�ֻ����scene��ͼ�в��ܿ���
                                     GameObject gameObj = hitInfo.collider.gameObject;
                                     Debug.Log("click object name is " + gameObj.name+""+ hitInfo.point);
                    if (gameObj.tag == "MapPlane")
                    {
                        //��������棬��û��Ӧ������Ǳ༭���򵯳�UI���ͷ�ʲô�����ӽ�ȥ  
                        //1�����棺
                        //2.1���༭��Panel.SetActive(true);
                        //���ٽ����κα�ĵ���¼�
                        print("����˵���Ŷ��");
                        PanelOfTwoButton.GetComponent<ALovelyEmpty>().HitPoint(hitInfo);
                        //  PanelOfTwoButton.SetActive(true);
                        //2.2���༭��
                    }
                    else if (gameObj.tag == "Zombe")
                    {
                        //��������棬�����������Ǳ༭����ݻ� 
                        //1�����棺Shot(this.Attack,this.Force);
                        //2.1���༭��DestroyImmediate(this.gameObject);
                        
                        //2.2���༭��
                    }
                    else if (gameObj.tag == "BigEvien") {
                        //��������棬��û��Ӧ������Ǳ༭����ݻ�
                        //1�����棺
                        //2.1���༭��DestroyImmediate(this.gameObject);

                        //2.2���༭��
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
