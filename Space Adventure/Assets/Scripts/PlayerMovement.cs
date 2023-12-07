 using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    Vector2 velocity;
    [SerializeField]
    float speed = default;
    [SerializeField]
    float acceleration = default;
    [SerializeField]
    float slowdown = default;
    [SerializeField]
    float jumpingForce = default;
    [SerializeField]
    int jumpLimit = 3;
    int jumpCount;
    GameObject rocketBurn;
    GameObject cameraForRocketMove;
    GameObject rocket;
    GameObject feet;
    Joystick joystick;
    JoystickButton joystickButton;
    bool jumping;
    float rocketSpeed;
    float cameraSpeed;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        joystickButton = FindObjectOfType<JoystickButton>();
        joystick = FindObjectOfType<Joystick>();
        rocketBurn = GameObject.FindWithTag("Rocket");
        rocket = GameObject.FindWithTag("RocketBurn");
        feet = GameObject.FindWithTag("Feet");
        cameraForRocketMove = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KeyboardController();
#else
                JoystickController();
#endif
        
    }
    void KeyboardController()
    {
        float movementInput = Input.GetAxis("Horizontal");
        Vector2 scale =transform.localScale;
         if(movementInput > 0 )
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            // þuanki deðer , ulaþýlmak istenen deðer , zaman geçtikçe eklenecek olan artýþ miktarý
            animator.SetBool("walking", true);
            scale.x = .3f;

        }
         else if(movementInput<0) {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            // þuanki deðer , ulaþýlmak istenen deðer , zaman geçtikçe eklenecek olan artýþ miktarý
            animator.SetBool("walking", true);
            scale.x = - .3f;
        }else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime);
            animator.SetBool("walking", false);
        }

         transform.localScale = scale;
         transform.Translate(velocity * Time.deltaTime);
        if (Input.GetKeyDown("space"))
        {
            StartJump();

        }
        if (Input.GetKeyUp("space"))
        {
            StopJump();
        }
    }

    void JoystickController()
    {
        float movementInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            // þuanki deðer , ulaþýlmak istenen deðer , zaman geçtikçe eklenecek olan artýþ miktarý
            animator.SetBool("walking", true);
            scale.x = .3f;

        }
        else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            // þuanki deðer , ulaþýlmak istenen deðer , zaman geçtikçe eklenecek olan artýþ miktarý
            animator.SetBool("walking", true);
            scale.x = -.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime);
            animator.SetBool("walking", false);
        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        if(joystickButton.isPressKey && !jumping )
        { 
            jumping = true;
            StartJump();

        }
        if (!joystickButton.isPressKey && jumping)
        {
            jumping = false;
            StopJump();
        }
    }

    void StartJump()
    {
        if(jumpCount < jumpLimit)
        {
            FindObjectOfType<VoiceController>().JumpVoice();
            FindObjectOfType<SliderController>().SliderValue(jumpLimit,jumpCount);
            rb2d.AddForce(new Vector2(0,jumpingForce),ForceMode2D.Impulse);
            animator.SetBool("jumping", true);
            
        }
        
    }
    void StopJump()
    {
        animator.SetBool("jumping", false);
        jumpCount++;
        FindObjectOfType<SliderController>().SliderValue(jumpLimit, jumpCount);
    }
    public void ResetJump()
    {
        jumpCount = 0;
        FindObjectOfType<SliderController>().SliderValue(jumpLimit, jumpCount);
        //Debug.Log("Reset Jump Worked ");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DeathPosition") {
            FindObjectOfType<GameController>().GameOver();
        }
    }
    public void GameOver()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RocketCollider")
        {
            ResetJump();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            rocket.GetComponent<SpriteRenderer>().enabled = true;
            rocketBurn.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(ApplyRocketForce()); 
            feet.GetComponent<Collider2D>().enabled = false;
            Debug.Log("Temas var");
        }
    }
    IEnumerator ApplyRocketForce()
    {
        cameraSpeed = 5f;
        rocketSpeed = 7f;
        
            if (LevelOptions.ReadEasyValue() == 1)
            {
            rocketSpeed = 7f;
        }
            if (LevelOptions.ReadMediumValue() == 1)
            {
            rocketSpeed = 8.9f;
        }
            if (LevelOptions.ReadHardValue() == 1)
            {
            rocketSpeed = 9.5f;
        }
        
        //rocketMaxSpeed = 20f;
        counter = 0f;
        GetComponent<Collider2D>().enabled = false;
        rb2d.velocity = Vector2.zero;
        while (counter < 3f)
        {
            rb2d.velocity = transform.up * rocketSpeed;
            //rb2d.AddForce(transform.up* rocketMaxSpeed, ForceMode2D.Force);
            cameraForRocketMove.transform.position += transform.up * cameraSpeed * Time.deltaTime;          
            yield return null;
            counter += Time.deltaTime;
        }
        GetComponent<Collider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        rocket.GetComponent<SpriteRenderer>().enabled = false;
        rocketBurn.GetComponent<SpriteRenderer>().enabled = false;
        feet.GetComponent<Collider2D>().enabled = true;
    }
}
