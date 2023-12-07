using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RocketDetector : MonoBehaviour
{
    GameObject player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            GetComponentInParent<Rocket>().CloseRocket();
            FindObjectOfType<VoiceController>().RocketVoice();
            player.transform.SetParent(null);  
        }
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}
