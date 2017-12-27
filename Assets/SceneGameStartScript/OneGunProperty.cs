using System;
using System.Collections;
using System.Collections.Generic;

public class OneGunProperty 
{
    private ProMode ThisGunMode;
    public OneGunProperty()
    {

        ThisGunMode = new ProMode(ProMode.PROMode.GUN);

    }
    //道具包含任务，背包元素，技能三种   
    //================================== 
    public ProMode.PROMode Skill_Mode()
    {
        return ThisGunMode.THISMODE;
    }

}
