using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    PolygonCollider2D polygonCollider2DPlatform2;
    bool move  ;
    float randomSpeed;
    float min, max;

    public bool Move
    {
        get { return move; }   // get method
        set { move = value; }
    }
    
    void Start()
    {

        polygonCollider2D = GetComponent<PolygonCollider2D>();
        //polygonCollider2DPlatform2 = GetComponent<PolygonCollider2D>();

        if (LevelOptions.ReadEasyValue() == 1)
        {
            randomSpeed = Random.Range(0.4f, 1.0f);
        }
        if (LevelOptions.ReadMediumValue() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);
        }
        if (LevelOptions.ReadHardValue() == 1)
        {
            randomSpeed = Random.Range(1.0f, 1.9f);
        }
        float objWidth =  polygonCollider2D.bounds.size.x / 2;
      //  float objWidth2 = polygonCollider2DPlatform2.bounds.size.x / 2;
        if (transform.position.x > 0) 
        {
            min = objWidth;
            max = ScreenCalculator.Instance.Width - objWidth;
        } else
        {
            min = -ScreenCalculator.Instance.Width + objWidth;
            max = -objWidth;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX , transform.position.y);
            transform.position = pingPong;

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == ("Feet"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();        }
    }
}
