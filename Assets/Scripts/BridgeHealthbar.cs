using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeHealthbar : MonoBehaviour
{
    public Slider HPbar;
    public Bridge Bridge;
    public Gradient gradient;
    public Image fill;
    
    void Start()
    {
        HPbar.maxValue = Bridge.Durability;
        HPbar.value = Bridge.Durability;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        float newValue = Bridge.Durability;
         HPbar.value = Mathf.Lerp(HPbar.value, newValue, 0.1f);
         fill.color = gradient.Evaluate(HPbar.normalizedValue);
    }
}
