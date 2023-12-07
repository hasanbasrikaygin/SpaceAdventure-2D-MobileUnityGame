using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlatformPool : MonoBehaviour
{    
    [SerializeField]
    List<GameObject> platformPrefabs;
    [SerializeField]
    GameObject deathPlatformPrefab;
    List<GameObject> platforms = new List<GameObject>();
    Vector2 platformPosition;
    [SerializeField]
    float platformDistance = default;
    [SerializeField]
    GameObject playerPrefab = default;
    Vector2 playerPosition;
   public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ProducePlatform();
       
    }
    void Update()
    {
        // ekranda alt kýsýmda kalarak gözükmeyen platformlarýn taþýnmasý
        if (platforms[platforms.Count-1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculator.Instance.Height) {
        PlacePlatform();
        }
    }
    void ProducePlatform()
    {   
        platformPosition = new Vector2 (0, 0);
        playerPosition = new Vector2 (0, 0.5f);

        player = Instantiate(playerPrefab, playerPosition , Quaternion.identity);
        
        GameObject firstPlatform = Instantiate(platformPrefabs[0], platformPosition, Quaternion.identity);
            player.transform.parent = firstPlatform.transform; // ilk platformun üzreinde oyuncunun durmasý için 
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Move = true;
        
        for (int i = 0; i < 8; i++)
        {
            float random = Random.Range(0.0f, 1.0f);
            GameObject platform;
            if (random < 0.3f)
            {
                platform = Instantiate(platformPrefabs[0], platformPosition, Quaternion.identity);
            }
            else if(0.3 <random && random < 0.6)
            {
                 platform = Instantiate(platformPrefabs[1], platformPosition, Quaternion.identity);
            }
            else
            {
                platform = Instantiate(platformPrefabs[2], platformPosition, Quaternion.identity);
            }
            
            platforms.Add (platform);  
            platform.GetComponent<Platform>().Move = true;
            NextPlatformPosition();
            float randomItem = Random.Range(0,3.8f);
            if (randomItem<2f) {
                platform.GetComponent<Gold>().OpenGold();
            }
           else if(randomItem < 2.4f)//
            {
                platform.GetComponent<Rocket>().OpenRocket();
            }
            else if (randomItem < 2.9f)
            {
                platform.GetComponent<GoldChest>().OpenGoldChest();
            }
            else if (randomItem < 3.4f)
            {
                platform.GetComponent<Shield>().OpenShield();
            }
        }
        GameObject deathPlatform = Instantiate(deathPlatformPrefab,platformPosition , Quaternion.identity);
        deathPlatform.GetComponent<DeathPlatform>().Move = true;
        platforms.Add(deathPlatform);
        NextPlatformPosition() ; 
    }
    void PlacePlatform()
    {
        for (int i = 0;i < 5;i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i+5] = platforms[i];
            platforms[i] = temp;
            platforms[i+5].transform.position = platformPosition;
            if (platforms[i+5].gameObject.tag=="Platform")
            {
                platforms[i + 5].GetComponent<Rocket>().CloseRocket();
                platforms[i+5].GetComponent<Gold>().CloseGold();
                platforms[i + 5].GetComponent<GoldChest>().CloseGoldChest();
                float randomItem = Random.Range(0, 3.8f);
                if (randomItem < 2.1f)
                {
                    platforms[i + 5].GetComponent<Gold>().OpenGold();
                    
                }
                else if (randomItem < 2.5f  )
                {
                    platforms[i + 5].GetComponent<Rocket>().OpenRocket();
                    
                }
                else if (randomItem < 3f )
                {
                    platforms[i + 5].GetComponent<GoldChest>().OpenGoldChest();
                   
                }
                else if (randomItem < 3.3f)
                {
                    platforms[i + 5].GetComponent<Shield>().OpenShield();
                }
            }
            NextPlatformPosition ();

        }
    }
    void NextPlatformPosition()
    {
        platformPosition.y += platformDistance ;             
        if (LevelOptions.ReadMixedPlatformValue()==0)
        {
            EasyPosition();
        }
        else
        {
            MixedPosition();
        }      
    }
    void MixedPosition()
    {
float random = Random.Range(0.0f, 1.0f);
        if(random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;

        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
        }
    }
    bool way = true;
    void EasyPosition()
    {
        if(way)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
            way = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
            way = true;
        }
    }
}
