using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    GameObject shield = default;
    public void OpenShield()
    {
        shield.SetActive(true);
    }
    public void CloseShield()
    {
        shield.SetActive(false);
    }
}
