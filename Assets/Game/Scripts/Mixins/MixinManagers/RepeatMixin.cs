using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMixin : MixinBase {

    public MixinBase repeatMixin;

    public float repeatTimer;
    float repeatTime;

    public int repeatCount;
    int timesRepeated;
    bool repeating;

    public override void Action()
    {
        timesRepeated = 1;
        repeatTime = 0.0f;
        repeatMixin.CheckAndAction();
        repeating = true;
    }
    // Update is called once per frame
    void Update ()
    {
		if(repeating)
        {
            repeatTime += Time.deltaTime;
            if (repeatTime > repeatTimer)
            {
                repeatTime = 0.0f;
                repeatMixin.CheckAndAction();
                timesRepeated++;
                if (timesRepeated >= repeatCount)
                {
                    repeating = false;
                }
            }
        }
	}
}
