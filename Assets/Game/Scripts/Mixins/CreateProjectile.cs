using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProjectile : MixinBase {

    public Transform projectilePrefab;
    public Transform firePosition;

    public override void Action()
    {
        Instantiate(projectilePrefab, firePosition.position, firePosition.rotation);
    }

}
