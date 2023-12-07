using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChestDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            GetComponentInParent<GoldChest>().CloseGoldChest();
            FindObjectOfType<Score>().WinGoldChest();
        }
    }

}
