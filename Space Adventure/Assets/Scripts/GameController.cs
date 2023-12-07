using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour

{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public GameObject signboard;
    public GameObject menuButton;
    public GameObject slider;

    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver() {
        FindObjectOfType<VoiceController>().GameOverVoice();
        gameOverPanel.SetActive(true);
        UIClose();
        FindObjectOfType<Score>().GameOver();
        Debug.Log("GameOver");
        FindObjectOfType<PlayerMovement>().GameOver();
        FindObjectOfType<CameraMove>().GameOver();
    }
    public void ReturnGameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    void UIOpen()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        signboard.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);
        
    }
    void UIClose() {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        signboard.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
        

    }
}
