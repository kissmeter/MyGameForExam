
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System;

public class MapDlock {
    public GameObject thisGame;
    public static int MapClockBigger=100;
    public List<Vector2> MapClockList = new List<Vector2>();
    private string mFolderName = "F:/MyGameSave/Map";
    private string mFileName = "MapSave";
    //生成的时候想办法吧，辣鸡！ 
    public int WhatClockMap;
    //public Dictionary<string, MapClock> Dic_Value;
    //public Link< Link< MapClock>> UpTransverse = new Link< Link< MapClock>>();
    //public Link< Link< MapClock>> DownTransverse = new Link<Link< MapClock>>();
    //public Link< Link< MapClock>> ReverseUpTransverse = new Link< Link< MapClock>>();
    //public Link< Link< MapClock>> ReverseDownTransverse = new Link< Link< MapClock>>();
    //List<MapClock> vertical = new List<MapClock>();
    //List<List<MapClock>> reversetransverse = new List<List<MapClock>>();
    //List<MapClock> reversevertical = new List<MapClock>();

    //Link<int> transverse = new Link<int>();
    //Link<int> vertical = new Link<int>();
    //-----------------------------
    public Dictionary<int,Dictionary<int, MapClock>> AllMapDlock = new Dictionary<int, Dictionary<int, MapClock>>();

    //如果最初创建，那么用这个 -------------------------



    //
    public MapDlock(string mFolderName,string mFileName,GameObject thisGame)
    {
        //Link<MapClock> AddOnece = new Link<MapClock>();
        //MapClock MapOnece = new MapClock(0,0);
        //AddOnece.Add(MapOnece);
        //UpTransverse.Add(AddOnece);

        //this.mFolderName = mFolderName;
        //this.mFileName = mFileName;
        //Dic_Value = new Dictionary<string,MapClock>();
        //Dic_Value.Add("map", UpTransverse.GetElem(0).GetElem(0));
        //-------------------------------
        this.thisGame = thisGame;

        AddAMapDlockAClock(0, 0);
    

        this.mFolderName = mFolderName;
        this.mFileName   = mFileName;
        //-------------------------------
    }
    //如果是读取存储，那么用这个 
    public MapDlock(byte[] BYTE) {



    }
    //This is API of the next void-------------------------
    //Whenever you need add one new mapclock,just use int!
    public void AddAMapDlockAClock(int i ,int j)
    {
        Dictionary<int, MapClock> AddDictionary = new Dictionary<int, MapClock>();
       
        MapClockList.Add(new Vector2(i, j));
      //  Debug.Log("ADD1");
        MapClock NextMapOnece = new MapClock(i, j, MapClockBigger, thisGame.transform, thisGame.transform.gameObject);
        AddDictionary.Add(j, NextMapOnece);
     //   Debug.Log("ADD2");
        AllMapDlock.Add(WhatClockMap, AddDictionary);
        WhatClockMap++;
      //  Debug.Log("ADD3");
    }
    //void GoUp(int newi,int newj) {
    //    //这里要判定是哪个transverse进行了改变，up和down确认up和down，而另一个反之，还要比较count和新位置的大小来确认是不是新地图 
    //    if (newi > 0)
    //    {
    //        if (newj > 0)
    //        {
    //            if (newj > UpTransverse.GetElem(newi + 1).Count())
    //            {
    //                Link<MapClock> AddOnece = new Link<MapClock>();
    //                MapClock MapOnece = new MapClock(newi, newj);
    //                AddOnece.Add(MapOnece);
    //                UpTransverse.Add(AddOnece);
    //            }
    //            else
    //            {
    //                return;
    //            }
    //        }
    //        else if (newj < 0)
    //        {
    //            return;
    //        }
    //        //MapClock newMapclock = new MapClock(newi, newj);
    //        //Dic_Value.Add("map", newMapclock);
    //    }
    //    else
    //    {
    //        if (newj > 0)
    //        {
    //            if (newj > ReverseUpTransverse.GetElem(newi+1).Count())
    //            {
    //                Link<MapClock> AddOnece = new Link<MapClock>();
    //                MapClock MapOnece = new MapClock(newi, newj);
    //                AddOnece.Add(MapOnece);
    //                ReverseUpTransverse.Add(AddOnece);
    //            }
    //            else
    //            {
    //                return;
    //            }
    //        }
    //        else if (newj < 0)
    //        {
    //            return;
    //        }

    //    }

    //}
    //void GoDown(int newi, int newj) {
    //    if (newj > 0)
    //    {
    //        return;

    //    }
    //    else if (newj < 0)
    //    {
    //        if (newi < 0)
    //        {
    //            if (newj < -ReverseDownTransverse.GetElem(-newi + 1).Count())
    //            {
    //                Link<MapClock> AddOnece = new Link<MapClock>();
    //                MapClock MapOnece = new MapClock(-newi, newj);
    //                AddOnece.Add(MapOnece);
    //                UpTransverse.Add(AddOnece);
    //            }
    //            else
    //            {
    //                return;
    //            }

    //        }
    //        else
    //        {
    //            if (newj < -DownTransverse.GetElem(newi + 1).Count())
    //            {
    //                Link<MapClock> AddOnece = new Link<MapClock>();
    //                MapClock MapOnece = new MapClock(newi, newj);
    //                AddOnece.Add(MapOnece);
    //                UpTransverse.Add(AddOnece);
    //            }
    //            else
    //            {
    //                return;
    //            }

    //        }
    //    }
    //}
    //void GoLeft(int newi, int newj) {
    //    if (newi > 0) { return; }
    //    else {
    //        if (newj > 0)
    //        {
    //            if (newi< ReverseUpTransverse.Count()) {
    //                //比较，然后add到newj为止 
    //                for (int i = 0; newi < ReverseUpTransverse.GetElem(-newi -1).Count(); i++)
    //                {
    //                    Link<MapClock> AddOnece = new Link<MapClock>();
    //                    MapClock MapOnece = new MapClock(-newi, i);
    //                    AddOnece.Add(MapOnece);
    //                    ReverseUpTransverse.Add(AddOnece);
    //                }
    //            }
    //            else { return; }
    //        }
    //        else {


    //        }
    //        }
    //}
    //void GoRight(int newi, int newj) {
    //    if (newj > 0) { }
    //    else { }
    //}
    //private static string FileName
    //{
    //    get
    //    {
    //        return Path.Combine(FolderName, mFileName);
    //    }
    //}

    //private static string FolderName
    //{
    //    get
    //    {
    //        return Path.Combine(Application.persistentDataPath, mFolderName);
    //    }
    //}
    //public string GetPath() {
    //    return FolderName;
    //}
    public void CreateNewSmallMapIsClock(int i,int j)
    {
        bool getsomething = false;
        for (int k = 0; k < MapClockList.Count; k++)
        {
            if (MapClockList[k].x == i && MapClockList[k].y == j)
            {
                getsomething = true;
                Debug.Log("getsomething" + "MapClockList[k].x"+ MapClockList[k].x+"i=" + i + "MapClockList[k].x" + MapClockList[k].y+"j=" + j);
            }
            else {
             
            }
        }
        if (getsomething)
        {
            return;
        }
        else {
            MapClockList.Add(new Vector2(i, j));
            AddAMapDlockAClock(i, j);
        }
       

    }
    public void Flash(int PositionX,int PositionY) {
        int AimX = (int)(PositionX / MapClockBigger);
        int AimY = (int)(PositionY / MapClockBigger);
        CreateNewSmallMapIsClock(AimX, AimY);
   
    }
    //给他一个坐标，他将立刻把距离自己1格子以外的5+2+2+2+5个格子全部取消mesh  TransTheMeshToScene
    public void MakeItOutOfMeshFarAwayOfMe(int i,int j) {
        try
        {
            AllMapDlock[i - 2][j - 2].TransTheSceneToMesh();
        }
        catch { }
        try
        {
            AllMapDlock[i - 2][j - 1].TransTheSceneToMesh();
        }
        catch { }
        try
        {
            AllMapDlock[i - 2][j + 1].TransTheSceneToMesh();
        }
        catch { }
        try
        {
            AllMapDlock[i - 2][j + 2].TransTheSceneToMesh();
        }
        catch { }
        try
        {
            AllMapDlock[i - 2][j    ].TransTheSceneToMesh();
        }
        catch { }
        try
        {
            AllMapDlock[i + 2][j - 2].TransTheSceneToMesh();
        }
        catch { }
        try { 
           AllMapDlock[i + 2][j - 1].TransTheSceneToMesh();
        }
        catch { }
        try
            {
              AllMapDlock[i + 2][j + 1].TransTheSceneToMesh();
        }
        catch { }
        try
                {
              AllMapDlock[i + 2][j + 2].TransTheSceneToMesh();
            }
            catch { }
            try
                {
             AllMapDlock[i + 2][j    ].TransTheSceneToMesh();
        }
        catch { }
        try {
              AllMapDlock[i - 1][j - 2].TransTheSceneToMesh();
        }
        catch { }
        try {
             AllMapDlock[i - 1][j + 2].TransTheSceneToMesh();
        }
        catch { }
        try {
            AllMapDlock[i + 1][j - 2].TransTheSceneToMesh();
        }
        catch { }
        try{
            AllMapDlock[i + 1][j + 2].TransTheSceneToMesh();
        }
        catch { }
        try {
            AllMapDlock[i    ][j - 2].TransTheSceneToMesh();
        }
        catch { }
        try {
            AllMapDlock[i    ][j + 2].TransTheSceneToMesh();
        }
        catch { }
        

                                }
    //给他一个坐标，他将把自己3+2+3范围的格子全部显形 TransTheSceneToMesh
    public void MakeItGetMeshBehindOfMe(int i, int j)
    {
        try
        {
            AllMapDlock[i - 1][j - 1].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i - 1][j    ].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i - 1][j + 1].TransTheMeshToScene();
    }
        catch { }
        try
        {
            AllMapDlock[i    ][j - 1].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i    ][j + 1].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i + 1][j - 1].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i + 1][j    ].TransTheMeshToScene();
        }
        catch { }
        try
        {
            AllMapDlock[i + 1][j + 1].TransTheMeshToScene();
        }
        catch { }

    }
    public void CreateNewBigMapClock() { }
    public void SaveAllMap(string FloderName,string FileName)
    {
        string PathPlace= Path.Combine(Application.persistentDataPath, FloderName);
        PathPlace = Path.Combine(FloderName, mFileName);
        Debug.Log("这个存储我已经准备好了！存储目标为_________" + PathPlace);
        string values;
        string Allvalues="";
        for (int i = 0; i < MapClockList.Count; i++)
        {
            values = JsonMapper.ToJson(AllMapDlock[(int)MapClockList[0].x][(int)MapClockList[0].y]);
            Allvalues += values;
        }
       //values = JsonMapper.ToJson(AllMapDlock[0][0]);
        Debug.Log(Allvalues);
        //if (!Directory.Exists(PathPlace))
        //{
        //    Directory.CreateDirectory(PathPlace);
        //}
        Debug.Log(FileName);
        FileStream file = new FileStream(PathPlace, FileMode.Create);
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(Allvalues);
        file.Write(bts, 0, bts.Length);
        Debug.Log(bts);
        if (file != null)
        {
            file.Close();
            Debug.Log("IHaveWriteDone!");
        }
    }
    //System.Collections.IDictionary ms
    public void SaveOneMapToOneJson () { }
    public void GetOneMapFromOneJson() { }
    public void GetOneMap() { }
    //消灭一小块
    public void DestroyASmallBlock(Vector2 BigMapVector2, Vector3 SmallMapVector3)
    {
        try
        {
            FindOutBlock(BigMapVector2, SmallMapVector3).Clean();
        }
        catch {
            throw new ArgumentNullException("无法查找这个Block去毁灭，是不是出现了bug，讲道理你要非这么做也不是不可以呢，前辈！");
        }
    }
    
    //查找，返回一个mapblock对象 如果没有，那么返回的是null 
    public MapBlock FindOutBlock(Vector2 BigMapVector2, Vector3 SmallMapVector3)
    {
        int BigMapX = (int)BigMapVector2.x;
        int BigMapY = (int)BigMapVector2.y;

        for (int i = 0; i < MapClockList.Count; i++)
        {
            if (MapClockList[i].x == BigMapX && MapClockList[i].y == BigMapY)
            {
                return (AllMapDlock[BigMapX][BigMapY].ReturnAMapBlockYouFind((int)SmallMapVector3.x, (int)SmallMapVector3.y));
              

            }
        }
        return null;
    }
    //生成一小块mapblock
    public void ControlAPrefabNameOfBlock(Vector2 BigMapVector2, Vector3 SmallMapVector3, string NewName, string NewPrefabName) {
        try
        {
            FindOutBlock(BigMapVector2, SmallMapVector3).GetNewPrefabAndPicture(NewName, NewPrefabName);
        }
        catch {
            throw new ArgumentNullException("无法查找这个Block去改变名称和进一步可能的操作，是不是出现了bug，讲道理你要非这么做也不是不可以呢，前辈！");
           
        }
    }
    }

    
public class MapBlock
  {
    Renderer ThisRender;
    //Gameobject每次取一下适合名字的prefab 
    GameObject kk;
   public MapBlock(int MapBigger,int BigMapListNumberX,int BigMapListNumberY,int SmallMapListNumberX, int SmallMapListNumberY, int SmallMapListNumberZ,string PrefabName,string PictureName)
    {
       
     //  Renderer ThisRender=GameObject.Instantiate(kk,new Vector3(MapBigger * BigMapListNumberX- BigMapListNumberX /2+ SmallMapListNumberX, MapBigger * BigMapListNumberY - BigMapListNumberY / 2 + SmallMapListNumberY, SmallMapListNumberZ),kk.transform.rotation).GetComponent<Renderer>();
       this.BX = BigMapListNumberX;
       this.BY = BigMapListNumberY;
       this.SX = SmallMapListNumberX;
       this.SZ = SmallMapListNumberZ;
       this.PCN = PrefabName;
       this.PFN = PictureName;
       HaveBeenUse = true;
    }
    //public GameObject jj {

    //    get {
    //        for (int i = 0; i < Manager.AllPrefab.count; i++)
    //        {
    //            if (PFN == Manager.AllPrefab[i].name) {
    //                return Manager.AllPrefab[i].prefab;
    //            }
    //        }
    //    }
    //        }
    public bool HaveBeenUse = false;
    public int BX
    {
        get;
        set;
    }
    public int BY
    {
        get;
        set;
    }
    public int SX
    {
        get;
        set;
    }
    public int SY
    {
        get;
        set;
    }
    public int SZ
    {
        get;
        set;
    }
    public string PFN
    {
        get;
        set;
    }
    public string PCN
    {
        get;
        set;
    }
    public void Clean() {
        PFN = "StartCube";
        PCN = "StartPicture";
    }
    public void CleanWhoIsOnMyHead() {


    }
    public void GetNewPrefabAndPicture(string prefabName,string pictureName) {
        if (prefabName != null) {
            PFN = prefabName;
        }
        if (pictureName != null) {
            PCN = pictureName;
        }

    }
  
    public void DoNotUseYou() {
        ThisRender.enabled = false;
    }
    public void DoNotUseYouForEver() { }
    public void NowIUseYou() {
        ThisRender.enabled = true;
    }
}

