using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To play the Level 2.
    public void PlayGame()
    {

        // Loading the Scene.
        SceneManager.LoadScene("MainScene");

    }

    public void SettingsMenu()
    {

        // Loading the Scene.
        SceneManager.LoadScene("SettingUIMenuScene");

    }

    // Goes to the Main Menu Scene.
    public void ExitGame()
    {

        // Loading the Scene.
        SceneManager.LoadScene("MainMenuScene");

    }
}

