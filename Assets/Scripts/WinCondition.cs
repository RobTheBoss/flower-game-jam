using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI youWin;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        youWin.enabled = false;
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Loading the Scene.
            SceneManager.LoadScene("EndCutscene");

        }
    }
}