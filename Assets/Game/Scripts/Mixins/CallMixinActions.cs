using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMixinActions : MixinBase {

    public List<MixinBase> checkMixins;
    public List<MixinBase> actionsMixins;

    public override bool Check()
    {

        for (int i = 0; i < checkMixins.Count; i++)
        {
            if (!checkMixins[i].Check())
            {
                return false;
            }
        }
        return true;
    }

    public override void Action()
    {
        for (int i = 0; i < actionsMixins.Count; i++)
        {
            actionsMixins[i].Action();
        }
    }
}
