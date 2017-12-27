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
        TASK = 2

    }

    public PROMode THISMODE;

    public ProMode(PROMode GET) {
        THISMODE = GET;
    }


}
