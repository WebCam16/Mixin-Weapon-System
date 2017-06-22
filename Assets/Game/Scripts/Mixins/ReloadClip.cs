using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadClip : MixinBase
{

    public FloatData clip;
    public float initalClipSize;

    public float reloadTimer;
    float reloadTime;
    bool isReloading;



    public override bool Check()
    {
        return !isReloading;
    }

    public override void Action()
    {
        isReloading = true;
        reloadTime = 0;
    }

    public void Update()
    {
        if(isReloading)
        {
            reloadTime += Time.deltaTime;
            if(reloadTime > reloadTimer)
            {
                clip.SetData(initalClipSize);
                isReloading = false;
            }
        }
    }



}
