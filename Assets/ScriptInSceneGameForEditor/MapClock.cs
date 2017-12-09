using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClock 
{
    List<MapBlock> StoreMapBlock = new List<MapBlock>();
    GameObject ThisPlane;
    private GameObject ClockMapStartPlane;
    private MonoBehaviour ToCoroutine;
    private Transform ToTransform;
    public MapClock(int newBigMapListNumberX, int newBigMapListNumberY, int MapClockBigger,Transform GetMonobehaviour,GameObject MapStartPlane)
    {
        Mapbigger = MapClockBigger;
        BigMapListNumberX = newBigMapListNumberX;
        BigMapListNumberY = newBigMapListNumberY;
        ClockMapStartPlane = MapStartPlane;
        ToTransform = GetMonobehaviour;
        //  Debug.Log("MapClock成功创建出了一个对象");
        ThisBlock = new MapBlock[MapClockBigger, MapClockBigger];
        ToCoroutine = GetMonobehaviour.GetComponent<MonoBehaviour>();
        CreatAClockMapWhenFirstCome(Mapbigger, BigMapListNumberX, BigMapListNumberY);
       // ToCoroutine.StartCoroutine(YieldToCreateMap(Mapbigger, BigMapListNumberX, BigMapListNumberY));

    }
    public void CreatAClockMapWhenFirstCome(int mapBigger, int bigmaplistnumberx, int bigmaplistnumbery) {

        ThisPlane=MonoBehaviour.Instantiate(ClockMapStartPlane, new Vector3(ToTransform.position.x + mapBigger * bigmaplistnumberx, 0, ToTransform.position.y + mapBigger * bigmaplistnumbery), ToTransform.rotation)as GameObject;
        
    }
    public IEnumerator YieldToCreateMap(int mapBigger, int bigmaplistnumberx, int bigmaplistnumbery)
    {
        for (int i = 0; i < mapBigger; i++)
        {
            for (int j = 0; j < mapBigger; j++)
            {
                ThisBlock[i, j] = new MapBlock(Mapbigger, BigMapListNumberX, BigMapListNumberY, i, j, 0, "StartCube", "StartPicture");
                Debug.Log("生成一个了！" + i + "" + j);
                yield return new WaitForSeconds(0.2f);
            }
           
        }

    }
    public void CreatAEvirenment(int mapBigger,int bigmapnumberx,int bigmapnumbery,int SmallMapX,int SmallMapY,string Name,GameObject ToCreat) {
        Debug.Log((SmallMapX) + "" + (SmallMapY));
        ThisBlock[SmallMapX-1, SmallMapY-1] = new MapBlock(Mapbigger, bigmapnumberx, bigmapnumbery, SmallMapX, SmallMapY, 0, "StartCube", "StartPicture", ToCreat);
  

    }
    public MapBlock[,] ThisBlock;
    public int BigMapListNumberX
    {
        get;
        set;
    }
    public int BigMapListNumberY
    {
        get;
        set;
    }
    public int Mapbigger;
    public void CreateButNoMesh() { }
    public void CreateAndUseMesh()
    {

    }
    public void TransTheMeshToScene()
    {
        for (int i = 0; i < StoreMapBlock.Count; i++)
        {
           
                StoreMapBlock[i].NowIUseYou();
            
        }

    }
    public void TransTheSceneToMesh()
    {
        for (int i = 0; i < StoreMapBlock.Count; i++)
        {

            StoreMapBlock[i].DoNotUseYou();

        }
    }
    public MapBlock ReturnAMapBlockYouFind(int SmallX,int SmallY) {

        return null;
    }
   //从上而下不再使用某一个格子 
    public void DonotUse(int i,int j)
    {

        StoreMapBlock.Remove(ThisBlock[i, j]);
        ThisBlock[i, j].DoNotUseYou();

    }
    public void CreateToSceneWhenNoMesh()
    {

    }

    public void StoreToSomeWhere() { }

}
