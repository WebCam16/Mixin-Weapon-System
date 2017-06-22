using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRaycast : MixinBase {

    public Transform firePosition;
    public float range;

    public override void Action()
    {
        RaycastHit hit;
        if(Physics.Raycast(firePosition.position, firePosition.forward, out hit, range))
        {
            print("I hit " + hit.transform);
        }

    }
}
