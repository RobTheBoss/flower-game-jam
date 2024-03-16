using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    private bool inBounds = false;
    [SerializeField] GameManager gm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && inBounds)
            Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           inBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inBounds = false;
        }
    }

    private void Interact()
    {
        if (gm.fertilizier <= 0) return;

        gm.fertilizier -= 1;
        gm.UpdateHud();

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2.0f, transform.localScale.z);
    }
}
