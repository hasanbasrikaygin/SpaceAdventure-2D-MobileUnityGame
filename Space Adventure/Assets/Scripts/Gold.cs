using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    GameObject gold = default;
    public void OpenGold()
    {
        gold.SetActive(true);
    }
    public void CloseGold()
    {
        gold.SetActive(false);
    }
    
}
