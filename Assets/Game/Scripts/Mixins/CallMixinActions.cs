using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMixinActions : MonoBehaviour {

    public List<MixinBase> checkMixins;
    public List<MixinBase> actionsMixins;

    public void CallActions()
    {
        for (int i = 0; i < checkMixins.Count; i++)
        {
            if(!checkMixins[i].Check())
            {
                return;
            }
        }
        for (int i = 0; i < actionsMixins.Count; i++)
        {
            actionsMixins[i].Action();
        }
    }
}
