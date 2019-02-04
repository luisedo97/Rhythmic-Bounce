using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //Speed
    public float speedGlobal = 1f;
    //UI
    public TextMeshProUGUI scoreUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject gameUI;
    //State
    public bool gameIsPause = false;
    //Score
    private int score;

    private void Start()
    {
        StartCoroutine(SpeedIncrease());
        
        if (SceneManager.GetActiveScene().name == "Menu") {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            GameObject highScoreUI = GameObject.Find("High Score");
            if (highScore != 0)
            {
                highScoreUI.GetComponent<TextMeshProUGUI>().SetText("Best: " + highScore);
            }
            else
            {
                highScoreUI.SetActive(false);
            }
        }
    }

    private void Update()
    {
        //multipliquer = GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value;
        //Debug.Log("Multipliquer:"+multipliquer);
    }

    IEnumerator SpeedIncrease()
    {
        while (true)
        {
            if (!gameIsPause) {
                speedGlobal += 0.01f;
                yield return new WaitForSeconds(2f);
            }
        }
    }

    public void Jump()
    {
        score++;
        scoreUI.SetText(""+score);
    }

    public void GameOver()
    {
        //Debug.Log("HACELO!");
        //Time.timeScale = 0f;
        gameOverUI.SetActive(true);

        int highscore = PlayerPrefs.GetInt("HighScore",0);

        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", score);
            GameObject.Find("Message_Text").GetComponent<TextMeshProUGUI>().SetText("New Record");
        }
        
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().SetText(score+"");
        GameObject.Find("Best").GetComponent<TextMeshProUGUI>().SetText(highscore + "");
        gameUI.SetActive(false);
    }


    public void Pause()
    {
        if (gameIsPause)
        {
            //Resume
            gameIsPause = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            //Pause
            gameIsPause = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LoadMenu()
    {
        //Debug.Log("Load Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void RefreshGame()
    {
        //Debug.Log("Refresh Game...");
        DontDestroyOnLoad(GameObject.Find("Audio"));
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

}
