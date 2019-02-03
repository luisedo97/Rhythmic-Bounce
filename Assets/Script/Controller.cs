using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float speedGlobal = 1f;
    public TextMeshProUGUI score;
    public GameObject pause;
    public bool gameIsPause = false;


    private void Start()
    {
        StartCoroutine(SpeedIncrease());
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

    public void Jump(int countBouncing)
    {
        score.SetText(""+countBouncing);
    }


    public void Pause()
    {
        if (gameIsPause)
        {
            //Resume
            gameIsPause = false;
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            //Pause
            gameIsPause = true;
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void RefreshGame()
    {
        Debug.Log("Refresh Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

}
