using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClip : MixinActionable {

    public FloatData clip;
    public float ammoPerShot;
    public override bool Check()
    {
        if(clip.GetData() - ammoPerShot < 0)
        {
            if (actionMixin.Check())
            {
                actionMixin.Action();
            }
            return false;
        }
        return true;
    }

    public override void Action()
    {

        clip.incrementData(-ammoPerShot);
    }
}
