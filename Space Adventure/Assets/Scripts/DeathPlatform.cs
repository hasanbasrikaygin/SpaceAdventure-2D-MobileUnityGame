using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    bool move;
    float randomSpeed;
    float min, max;
  
    public bool Move
    {
        get { return move; }   // get method
        set { move = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float objWidth = boxCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            min = objWidth;
            max = ScreenCalculator.Instance.Width - objWidth;
        }
        else
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
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Feet")
        {

            
            if (Score.shield >0)
            {
            
                Debug.Log("Shield :");
                FindObjectOfType<Score>().LoseShield();
            }
            else
            {
                FindObjectOfType<GameController>().GameOver();
                Debug.Log("Shields" + Score.shield);
              
            }
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();

        }
    }
}
