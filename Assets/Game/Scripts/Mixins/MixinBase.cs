using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixinBase : MonoBehaviour {

    public virtual bool Check()
    {
        return true;
    }

	public virtual void Action()
    {

    }

    public void CheckAndAction()
    {
        if(Check())
        {
            Action();
        }
    }

}
