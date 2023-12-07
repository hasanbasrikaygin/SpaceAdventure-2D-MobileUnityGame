using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] 
    Sprite[] musicIcons = default;
    [SerializeField]
    Button musicButtons = default;
    
    // Start is called before the first frame update
    void Start()
    {
        if (LevelOptions.HasSave() == false)
        {
            LevelOptions.EasyAssignValue(1);
        }
        if (LevelOptions.MusicOpenHasSave() == false)
        {
            LevelOptions.MusicOpenAssignValue(1);
        }
        if (!LevelOptions.MixedPlatformHasSave())
        {
           LevelOptions.MixedPlatformValueAssignValue(1);
        }
        
        CheckMusicSettings();
      
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("ScoreBoard");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
   public void Music()
    {
        if(LevelOptions.MusicOpenReadValue()==1)
        {

            LevelOptions.MusicOpenAssignValue(0);
            MusicController.instance.MusicPlay(false);
            musicButtons.image.sprite = musicIcons[0];

        }else
        {
            LevelOptions.MusicOpenAssignValue(1);
            MusicController.instance.MusicPlay(true);
            musicButtons.image.sprite = musicIcons[1];
        }
    }
    void CheckMusicSettings()
    {
        if (LevelOptions.MusicOpenReadValue() == 1)
        {
            musicButtons.image.sprite = musicIcons[1];
            MusicController.instance.MusicPlay(true);
        }
        else
        {
            musicButtons.image.sprite = musicIcons[0];
            MusicController.instance.MusicPlay(false);
        }

    }

}
 