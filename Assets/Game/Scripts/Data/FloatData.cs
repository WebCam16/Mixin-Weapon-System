using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData : MonoBehaviour {
    [SerializeField]
    float data;
    [SerializeField]
    float maxData;

    public MixinBase updateMixin;

    public float GetData() { return data; }
    public float GetDataMax() { return maxData; }
    public void SetData(float newData)
    {
        data = newData;

        OnUpdated();
    }

    public void incrementData(float num)
    {
        data += num;
        OnUpdated();
    }

    void OnUpdated()
    {
        if (updateMixin)
        {
            if (updateMixin.Check())
            {
                updateMixin.Action();
            }
        }
    }



}
