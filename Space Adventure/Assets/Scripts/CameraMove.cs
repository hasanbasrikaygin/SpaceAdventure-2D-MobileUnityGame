using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxSpeed;
    public bool move;
    void Start()
    {
        move = true;
        if (LevelOptions.ReadEasyValue() == 1)
        {
            speed = 0.3f;
            acceleration = 0.04f;
            maxSpeed = 1.0f;
        }
        if (LevelOptions.ReadMediumValue() == 1)
        {
            speed = 0.5f;
            acceleration = 0.07f;
            maxSpeed = 1.7f;
        }
        if (LevelOptions.ReadHardValue() == 1)
        {
            speed = 0.8f;
            acceleration = 0.1f;
            maxSpeed = 2.5f;
        }
    }
    void Update()
    {
        MoveToCamera();
    }
    void MoveToCamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
    public void GameOver()
    {
        move = false;
    }
}
