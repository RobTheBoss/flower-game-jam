using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerScript : MonoBehaviour
{
    private bool inBounds = false;
    public float growthProgress = 0.0f;
    [SerializeField] GameManager gm;
    public Transform topOfFlower;
    private Animator anim;

    public AudioSource audioplayer;
    public AudioSource audioplayer1;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && inBounds)
            Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Insect")
        {
            gm.insectsAttacking++;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            inBounds = true;
            collision.gameObject.GetComponent<PlayerMovement>().preventFall = true;
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Insect")
        {
            gm.insectsAttacking--;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            inBounds = false;
            collision.gameObject.GetComponent<PlayerMovement>().preventFall = false;
        }
    }

    private void Interact()
    {
        
        if (gm.fertilizier <= 0) return;

        gm.fertilizier -= 1;

        audioplayer.Play();

        growthProgress += 10.0f;
        if (growthProgress > 100.0f)
            growthProgress = 100.0f;

        gm.UpdateHud();

        transform.localScale = new Vector3(growthProgress * 0.25f + 1, growthProgress * 0.25f + 1, transform.localScale.z);
    }

    public void Shake()
    {
        anim.SetBool("Shake", true);
    }

    public void UnShake()
    {
        anim.SetBool("Shake", false);
    }

    public void TakeDamage(float amount_)
    {
        audioplayer1.Play();
        growthProgress -= amount_;
        if (growthProgress < 0.0f)
            growthProgress = 0.0f;

        transform.localScale = new Vector3(growthProgress * 0.25f + 1, growthProgress * 0.25f + 1, transform.localScale.z);
    }
}
