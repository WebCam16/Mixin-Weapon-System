using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MixinBase {

    public Text text;
    public FloatData data;

    public override void Action()
    {
        text.text = data.GetData().ToString();
    }
}
