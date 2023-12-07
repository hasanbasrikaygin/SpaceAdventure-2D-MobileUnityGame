using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveController : MonoBehaviour
{
    // Start is called before the first frame update

    float backgroundPosition;
    float distance = 10.24f;
    void Start()
    {
        backgroundPosition = transform.position.y;
        FindObjectOfType<Planets>().PlanetPlace(backgroundPosition);
    }
    // Update is called once per frame
    void Update()
    {
        if(backgroundPosition + distance < Camera.main.transform.position.y) {
            BackgroundPlace();
        }
    }
    void BackgroundPlace()
    {
        backgroundPosition += (distance * 2) ;
        FindObjectOfType<Planets>().PlanetPlace(backgroundPosition);
        Vector2 newPosition = new Vector2(0,backgroundPosition);
        transform.position = newPosition;
    }
}
