using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUISlider : MixinBase {

    public RectTransform sliderForground;
    public FloatData data;
    public float maxWidth;

    void Start()
    {
        maxWidth = sliderForground.sizeDelta.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        sliderForground.sizeDelta = new Vector2(data.GetData() / data.GetDataMax() * maxWidth, sliderForground.sizeDelta.y);
	}
}
