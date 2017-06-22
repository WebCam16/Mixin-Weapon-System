using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimator : MixinBase {

    public Animator anim;
    public string trigger;

    public override void Action()
    {
        anim.SetTrigger(trigger);
    }
}
