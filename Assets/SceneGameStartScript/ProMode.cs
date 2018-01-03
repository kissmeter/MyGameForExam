using System;
using System.Collections;
using System.Collections.Generic;

public class ProMode {

    //public static ProMode THISPROMODE;

    //public static ProMode getInstance() {
    //    if (THISPROMODE == null)
    //    {
    //        THISPROMODE = new ProMode(GunMode.AB);
    //    }
    //    return THISPROMODE;
    //}

    public enum PROMode{

        GUN  = 0,
        SKILL= 1,
        TASK = 2,      //任务
        CONSU = 3,     //消耗品
        QUESTOFTASK=4  //任务道具
        

    }

    public PROMode THISMODE;

    public ProMode(PROMode GET) {
        THISMODE = GET;
    }


}
