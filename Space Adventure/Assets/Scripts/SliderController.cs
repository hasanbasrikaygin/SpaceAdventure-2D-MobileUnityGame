using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }
    public void SliderValue(int maxValues , int currentValue)
    {
        int sliderValues = maxValues - currentValue;
        slider.maxValue = maxValues;
        slider.value = sliderValues;
    }

}
