using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlatformPositionController : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = (int)LevelOptions.ReadMixedPlatformValue();
        // slider.value = PlayerPrefs.GetFloat("SliderValue");
    }
    
    public void OnSliderValueChanged(float value)
    {
        LevelOptions.MixedPlatformValueAssignValue((int)value);
        //PlayerPrefs.SetFloat("SliderValue", value);
    }

}
