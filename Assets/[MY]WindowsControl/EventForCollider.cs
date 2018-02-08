using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventForCollider : MonoBehaviour {
    private bool ToTrigger;
    UseRigid PlayerRigidUse;
    private List<GameObject> GameobjectInTrigger=new List<GameObject>();
	// Use this for initialization
	void Start () {
        //要有一个可靠的办法去寻找主角 
        PlayerRigidUse = GameObject.Find("OneRayPlayer").GetComponent<UseRigid>();

    }
    private void OnEnable()
    {
        ToTrigger = true;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (ToTrigger) {
            StartCoroutine(YieldInSetActive());
            //送回去
       
        }
	}
    public IEnumerator YieldInSetActive() {
        //yield return new WaitForSeconds(1f);
        yield return 1;
      //  PlayerRigidUse.GetThisTriggerGameObject(GameobjectInTrigger);
        CompareDistanceAndUseTalk();
        GameobjectInTrigger.Clear();
        ToTrigger = false;
        this.gameObject.SetActive(false);

    }
    private void CompareDistanceAndUseTalk()
    {
        GameObject Min = this.gameObject;
        if (GameobjectInTrigger.Count == 0)
        {
            return;
        }
        if (GameobjectInTrigger.Count == 1)
        {
            Min = GameobjectInTrigger[0];

        }
        else
        {
            Min = GameobjectInTrigger[0];
            for (int i = 1; i < GameobjectInTrigger.Count; i++)
            {
                //比较gameObjectThatTriggerGet[i]和gameObjectThatTriggerGet[i-1]与主角的距离大小_(:зゝ∠)_
                if (GameobjectInTrigger[i].transform.position.x + GameobjectInTrigger[i].transform.position.y - this.transform.position.x - this.transform.position.y < GameobjectInTrigger[i - 1].transform.position.x + GameobjectInTrigger[i - 1].transform.position.y - this.transform.position.x - this.transform.position.y)
                {
                    Min = GameobjectInTrigger[i];

                }
            }
        }

        //和min进行对话
        //在这里调用交互信息，这次交互成功了
        //声明如下，在这里只是成功调用和某个npc进行对话的命令罢了。
        GameObject.Find("EventSystem").GetComponent<TalkInfor>().TriggerATalk(Min, this.gameObject);

    }

    public void TransTriggerBool(UseRigid This) {
        PlayerRigidUse = This;
        ToTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "NPC")
        {
            Debug.Log("触发了碰撞" + other.gameObject.name);
            GameobjectInTrigger.Add(other.gameObject);
        }

    }
    
}
