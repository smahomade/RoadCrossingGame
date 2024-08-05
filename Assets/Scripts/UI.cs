using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI nextLevelText;
    public GameObject endScreen;
    public GameObject winText;
    public GameObject gameOverText;
    public GameObject pauseScreen;
    public GameObject nextLevelButton;
    private bool test = false;

    public static UI instace;

    public void Start()
    {
        UpdateLevelText();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex == totalScenes - 1)
        {
            nextLevelText.text = "Exit";
            test = true;
        }

    }
    private void Awake()
    {
        instace = this;
    }

    public void UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score.ToString();

    }

    public void UpdateLevelText()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        levelText.text = "Level: " + (currentScene.buildIndex).ToString();
    }



    public void SetEndScreen (bool didWin)
    {
        endScreen.SetActive(true);
        winText.SetActive(didWin);
        nextLevelButton.SetActive(didWin);
        gameOverText.SetActive(!didWin);
        Time.timeScale = 0.0f;
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void OnNextLevelButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        //Scene currentScene = SceneManager.GetActiveScene();
        if (test == true)
        {  // MAKE A BUTTON TO QUIT GAME OR GO TO MAIN MENU
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
            Debug.Log(test + "Quit game when last scene is finished");
        }
        else
        {   // go to next level
            SceneManager.LoadScene(currentSceneIndex + 1);
            Time.timeScale = 1.0f;
            Debug.Log(test + "next level if player is not in last scene");
        }
    }

    public void SetPauseScreen()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
    
    public void ClosePauseScreen()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
