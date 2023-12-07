using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            GetComponentInParent<Shield>().CloseShield();
            FindObjectOfType<Score>().WinShield();
        }
    }
}
