using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChest : MonoBehaviour
{
    [SerializeField]
    GameObject goldChest = default;
    public void OpenGoldChest()
    {
        goldChest.SetActive(true);
    }
    public void CloseGoldChest()
    {
        goldChest.SetActive(false);
    }
}
