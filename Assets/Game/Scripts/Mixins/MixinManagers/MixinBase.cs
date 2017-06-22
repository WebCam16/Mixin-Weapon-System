using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MixinBase : MonoBehaviour {

    public string Name;


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
