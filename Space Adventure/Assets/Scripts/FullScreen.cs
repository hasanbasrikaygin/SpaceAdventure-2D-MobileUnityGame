using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent <SpriteRenderer> ();
        Vector2 tempScale = transform.localScale;
        float spriteGenislik = spriteRenderer.size.x; // obje boyutu
        float ekranYuksekik = Camera.main.orthographicSize * 2.0f; // ekran kamera yuksekligi
        float ekranGenislik = ekranYuksekik / Screen.height * Screen.width ; // ekran geniþiliði

        tempScale.x = ekranGenislik / spriteGenislik;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
