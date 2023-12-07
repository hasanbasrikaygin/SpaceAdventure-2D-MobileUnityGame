using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rocket : MonoBehaviour
{
    [SerializeField]
    GameObject rocket = default;
    public void OpenRocket()
    {
        rocket.SetActive(true);    
    }
    public void CloseRocket()
    {
        rocket.SetActive(false);
    }   
}
