using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MixinBase : MonoBehaviour {

    public string Name;
    [HideInInspector]
    public bool showMixin;
    [HideInInspector]
    public bool showInfo;


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
