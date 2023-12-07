using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    bool goldCounter = true;
    int score;
    int maxScore;
    [SerializeField]
    TextMeshProUGUI scoreText = default;
    int gold;
    public static int shield;
    int maxGold;
    SpriteRenderer[] spriteShieldRenderers;
    [SerializeField]
    TextMeshProUGUI goldText = default;

    [SerializeField]
    TextMeshProUGUI gameOverScoreText = default;

    [SerializeField]
    TextMeshProUGUI gameOverGoldText = default;
    void Start()
    {
        goldText.text = " x " + gold;
        shield=0;
        Debug.Log("Baþlangýç");
        GameObject targetObject = GameObject.Find("HealthBar");
        spriteShieldRenderers = targetObject.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(goldCounter)
        {
        score = (int)Camera.main.transform.position.y;
        scoreText.text = "Score : " + score; 
        }
    }
    public void WinGold()
    {
        FindObjectOfType<VoiceController>().GoldVoice();
        gold++;
        goldText.text = " x " + gold;
    }
    public void WinShield()
    {
        FindObjectOfType<VoiceController>().ShieldVoice();
        if (shield < spriteShieldRenderers.Length)
        {
            spriteShieldRenderers[shield].enabled = true; // Sadece kazanýlan kalkan sayýsý kadar kalp sprite'ýný görünür yap
            shield++;
          //  Debug.Log("Shields: " + shield);
        }
    }
    public void LoseShield()
    {
        if (shield > 0)
        {
            shield--;
            spriteShieldRenderers[shield].enabled = false; // Azaltýlmýþ hali ile ilgili kalp sprite'ýný görünmez yap
            Debug.Log("Shields: " + shield);
        }
    }

    public void WinGoldChest()
    {
        FindObjectOfType<VoiceController>().GoldVoice();
        gold+=10;
        goldText.text = " x " + gold;
    }
    public void GameOver() 
    {
        if (LevelOptions.ReadEasyValue()==1)
        {
            maxGold = LevelOptions.ReadEasyGoldValue();
            maxScore = LevelOptions.ReadEasyScoreValue();
            if(score > maxScore)
            {
                LevelOptions.EasyScoreAssignValue(score);
                
            }
            if(gold > maxGold)
            {
                LevelOptions.EasyGoldAssignValue(gold);
            }
        }
        //
        if (LevelOptions.ReadMediumValue() == 1)
        {
            maxGold = LevelOptions.ReadMediumGoldValue();
            maxScore = LevelOptions.ReadMediumScoreValue();
            if (score > maxScore)
            {
                LevelOptions.MediumScoreAssignValue(score);

            }
            if (gold > maxGold)
            {
                LevelOptions.MediumGoldAssignValue(gold);
            }
        }
        //
        if (LevelOptions.ReadHardValue() == 1)
        {
            maxGold = LevelOptions.ReadHardGoldValue();
            maxScore = LevelOptions.ReadHardScoreValue();
            if (score > maxScore)
            {
                LevelOptions.HardScoreAssignValue(score);

            }
            if (gold > maxGold)
            {
                LevelOptions.HardGoldAssignValue(gold);
            }
        }
        //
        goldCounter = false;
        gameOverScoreText.text = " Score : " + score;
        gameOverGoldText.text = " x " + gold; 
    }
}
