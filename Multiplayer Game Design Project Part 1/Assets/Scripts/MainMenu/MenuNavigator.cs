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
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }
    // Update is called once per frame
    void Update()
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
}