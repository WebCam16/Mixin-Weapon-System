using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMixin : MixinBase {

    public int repeatCount;
    int timesRepeated;
    public float repeatTimer;
    float repeatTime;
    bool isRepeating;

    public MixinBase actionMixin;


    public override void Action()
    {
        actionMixin.CheckAndAction();
        isRepeating = true;
        repeatTime = 0;
        timesRepeated = 1;
    }

    public void Update()
    {
        if(isRepeating)
        {
            repeatTime += Time.deltaTime;
            if(repeatTime > repeatTimer)
            {
                actionMixin.CheckAndAction();
                timesRepeated++;
                repeatTime = 0.0f;
                if (timesRepeated > repeatCount)
                {
                    isRepeating = false;
                }
            }
        }
    }
}
