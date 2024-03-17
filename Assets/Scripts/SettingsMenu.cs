using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
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
        SceneManager.LoadScene("MainMenuUIScene");

    }
    public void Settings()
    {

        // Loading the Scene.
        SceneManager.LoadScene("SettingsMenuUIScene");


    }
    public void Quit()
    {

        // Loading the Scene.
        
    }
}

