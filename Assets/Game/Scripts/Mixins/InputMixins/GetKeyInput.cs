using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKeyInput : InputBase {

    void Update()
    {
        if(Input.GetKey(inputKey))
        {
            inputAction.CheckAndAction();
        }
    }
}
