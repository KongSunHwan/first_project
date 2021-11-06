using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMgr : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject gameOverText;
    public Button buttonbox;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        /*
        if (gameOver == true)
        {
            Debug.Log("GameOver!!!!!");
            gameOverText.SetActive(gameOver);
            Time.timeScale = 0;
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOver == false)
            {
                Debug.Log("GameOver!!!!!");
                gameOverText.SetActive(gameOver);
            }
        }
        */
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            Time.timeScale = 0;
            buttonbox.onClick.Invoke();

        }
        /*
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Application.LoadLevel(0);
                }
        */
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game Exit!!!!!!!");
            Time.timeScale = 0;
            Application.Quit();
        }
        */
    }

}
