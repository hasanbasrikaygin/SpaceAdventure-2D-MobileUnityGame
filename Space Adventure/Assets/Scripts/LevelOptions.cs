using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelOptions 
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string mediumScore = "mediumScore";
    public static string hardScore = "hardScore";

    public static string easyGold = "easyGold";
    public static string mediumGold = "mediumGold";
    public static string hardGold = "hardGold";

    public static string musicOpen = "musicOpen";

    public static string mixedPlatform = "mixedPlatform";
    public static void MixedPlatformValueAssignValue(int mixedPlatform)
    {
        PlayerPrefs.SetInt(LevelOptions.mixedPlatform, mixedPlatform);
    }
    public static int ReadMixedPlatformValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.mixedPlatform);
    }
    
    //
    public static void EasyAssignValue(int easy)
    {
        PlayerPrefs.SetInt(LevelOptions.easy, easy);
    }
    public static int ReadEasyValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.easy);
    }
    public static void MediumAssignValue(int medium)
    {
        PlayerPrefs.SetInt(LevelOptions.medium, medium);
    }
    public static int ReadMediumValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.medium);
    }
    public static void HardAssignValue(int hard)
    {
        PlayerPrefs.SetInt(LevelOptions.hard, hard);
    }
    public static int ReadHardValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.hard);
    }
    //
    public static void EasyScoreAssignValue(int easyScore)
    {
        PlayerPrefs.SetInt(LevelOptions.easyScore, easyScore);
    }
    public static int ReadEasyScoreValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.easyScore);
    }
    public static void MediumScoreAssignValue(int mediumScore)
    {
        PlayerPrefs.SetInt(LevelOptions.mediumScore, mediumScore);
    }
    public static int ReadMediumScoreValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.mediumScore);
    }
    public static void HardScoreAssignValue(int hardScore)
    {
        PlayerPrefs.SetInt(LevelOptions.hardScore, hardScore);
    }
    public static int ReadHardScoreValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.hardScore);
    }

    //
    public static void EasyGoldAssignValue(int easyGold)
    {
        PlayerPrefs.SetInt(LevelOptions.easyGold, easyGold);
    }
    public static int ReadEasyGoldValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.easyGold);
    }
    public static void MediumGoldAssignValue(int mediumGold)
    {
        PlayerPrefs.SetInt(LevelOptions.mediumGold, mediumGold);
    }
    public static int ReadMediumGoldValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.mediumGold);
    }
    public static void HardGoldAssignValue(int hardGold)
    {
        PlayerPrefs.SetInt(LevelOptions.hardGold, hardGold);
    }
    public static int ReadHardGoldValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.hardGold);
    }  
    //
    public static bool HasSave()
    {
        if(PlayerPrefs.HasKey(LevelOptions.easy) || PlayerPrefs.HasKey(LevelOptions.medium) || PlayerPrefs.HasKey(LevelOptions.hard))
        {
            return true;
        }
        else { 
return false; } 
    }
    //
    public static void MusicOpenAssignValue(int musicOpen)
    {
        PlayerPrefs.SetInt(LevelOptions.musicOpen, musicOpen);
    }
    public static int MusicOpenReadValue()
    {
        return PlayerPrefs.GetInt(LevelOptions.musicOpen);
    }

    //
    public static bool MusicOpenHasSave()
    {
        if (PlayerPrefs.HasKey(LevelOptions.musicOpen))

        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //
public static bool MixedPlatformHasSave()
{
    if (PlayerPrefs.HasKey(LevelOptions.mixedPlatform))

    {
        return true;
    }
    else
    {
        return false;
    }
}
}
