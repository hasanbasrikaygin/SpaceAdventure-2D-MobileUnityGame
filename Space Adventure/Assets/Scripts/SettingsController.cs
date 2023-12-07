using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if (slider == null)
        {
            Debug.LogError("Slider is not assigned in the Inspector!");
        }
        else
        {
            slider.onValueChanged.AddListener(
            delegate { OnPlatformSliderValueChanged(); }
            );
        }

        if (LevelOptions.ReadEasyValue() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }
        if (LevelOptions.ReadMediumValue() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (LevelOptions.ReadHardValue() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
        

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ButtonSelected(string level) { 
        switch (level)
        {
            case "easy":
                LevelOptions.EasyAssignValue(1);
                LevelOptions.MediumAssignValue(0);
                LevelOptions.HardAssignValue(0);
                easyButton.interactable = false;
                mediumButton.interactable = true; 
                hardButton.interactable = true;
             break;
            case "medium":
                LevelOptions.EasyAssignValue(0);
                LevelOptions.MediumAssignValue(1);
                LevelOptions.HardAssignValue(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                LevelOptions.EasyAssignValue(0);
                LevelOptions.MediumAssignValue(0);
                LevelOptions.HardAssignValue(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
        }
}
    public void OnPlatformSliderValueChanged()
    {
        
        if(slider.value == 0.0f)
        {
            LevelOptions.MixedPlatformValueAssignValue(0);
            // PlayerPrefs.SetFloat("SliderValue", slider.value);
            Debug.Log("0");
        }if(slider.value == 1.0f) 
        {
            LevelOptions.MixedPlatformValueAssignValue(1);
            //PlayerPrefs.SetFloat("SliderValue", slider.value);
        }
    }
}
