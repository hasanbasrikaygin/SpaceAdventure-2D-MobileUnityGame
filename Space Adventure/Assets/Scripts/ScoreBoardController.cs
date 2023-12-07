using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreBoardController : MonoBehaviour
{
    public TextMeshProUGUI easyGold , easyScore , mediumGold , mediumScore , hardGold , hardScore ;
    // Start is called before the first frame update
    void Start()
    {
        easyGold.text = " X " + LevelOptions.ReadEasyGoldValue();
        easyScore.text = "Score : "+ LevelOptions.ReadEasyScoreValue();

        mediumGold.text = " X " + LevelOptions.ReadMediumGoldValue();
        mediumScore.text = "Score : " + LevelOptions.ReadMediumScoreValue();

        hardGold.text = " X " + LevelOptions.ReadHardGoldValue();
        hardScore.text = "Score : " + LevelOptions.ReadHardScoreValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
