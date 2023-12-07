using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x< -ScreenCalculator.Instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = -ScreenCalculator.Instance.Width;
            transform.position = temp;
        }
        if (transform.position.x > ScreenCalculator.Instance.Width)
        {
            Vector2 temp = transform.position;
            temp.x = ScreenCalculator.Instance.Width;
            transform.position = temp;
        }

    }
}
