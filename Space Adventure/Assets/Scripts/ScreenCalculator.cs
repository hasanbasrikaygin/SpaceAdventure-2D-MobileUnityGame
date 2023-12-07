using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator : MonoBehaviour
{
    public static ScreenCalculator Instance;

    float height;
    float width;

    public float Height
    {
        get { return height; }
    }
    public float Width { get { return width; } } 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

    }
}
