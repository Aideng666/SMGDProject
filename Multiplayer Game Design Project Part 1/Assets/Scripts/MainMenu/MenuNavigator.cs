using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    bool levelFailed = false;
    bool levelComplete = false;
    bool mainMenu = false;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu = true;
        }

        if (SceneManager.GetActiveScene().name == "Level Failed")
        {
            levelFailed = true;
        }

        if (SceneManager.GetActiveScene().name == "Level Complete")
        {
            levelComplete = true;
        }


        if (levelComplete)
        {
            FindObjectOfType<AudioManager>().Play("Portal");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("MainMenu");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("MainMenu") && !FindObjectOfType<AudioManager>().IsPlaying("Portal"))
        {
            FindObjectOfType<AudioManager>().Play("MainMenu");
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainMenu = true;
        }

        if (SceneManager.GetActiveScene().name == "Level Failed")
        {
            levelFailed = true;
        }

        if (SceneManager.GetActiveScene().name == "Level Complete")
        {
            levelComplete = true;
        }

        if (mainMenu && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }

        if (levelComplete && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }

        if (levelFailed && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void StartButton()
    {
        if (mainMenu)
        {
            SceneManager.LoadScene("Level1");
        }    
    }

    public void FailedRetryButton()
    {
        if (levelFailed)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void WinButton()
    {
        if (levelComplete)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}