using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyDownInput : InputBase
{
    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            inputAction.CheckAndAction();
        }
    }
}
