using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            Debug.Log("Player Wins!");
            youWin.enabled = true;
            restartButton.SetActive(true);
        }
    }
}