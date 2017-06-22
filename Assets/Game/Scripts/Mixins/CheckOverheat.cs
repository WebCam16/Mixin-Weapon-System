using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverheat : MixinBase {

    bool isOverheated;
    public FloatData overheatBuffer;
    public float overheatedTimer;
    float overheatTime;

    public float decreaseTimer;
    float decreaseTime;
    public float decreaseAmount;
    public float step;

    public override bool Check()
    {
        return !isOverheated;
    }

    public override void Action()
    {
        overheatBuffer.incrementData(step);
        if(overheatBuffer.GetData() >= overheatBuffer.GetDataMax())
        {
            isOverheated = true;
        }
    }

    void Update()
    {
        if(isOverheated)
        {
            overheatTime += Time.deltaTime;
            if(overheatTime > overheatedTimer)
            {
                isOverheated = false;
                overheatTime = 0.0f;
            }
        }
        decreaseTime += Time.deltaTime;
        if (overheatBuffer.GetData() > 0)
        {
            if (decreaseTime > decreaseTimer)
            {
                overheatBuffer.incrementData(-decreaseAmount);
                decreaseTime = 0.0f;
            }
        }

    }


}
