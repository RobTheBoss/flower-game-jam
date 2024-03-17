using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InsectScript : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float minimumDistance;

    private GameManager walletSystem;
    private FlowerScript flowerScript;

    private Transform flowerBottomTransform;
    private Transform flowerTopTransform;

    private Rigidbody2D rb;
    private Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        walletSystem = GameObject.Find("GameManager").GetComponent<GameManager>();
        flowerScript = GameObject.Find("Flower").GetComponent<FlowerScript>();
        rb = GetComponent<Rigidbody2D>();

        flowerBottomTransform = GameObject.Find("Flower").transform;
        flowerTopTransform = GameObject.Find("Flower").GetComponent<FlowerScript>().topOfFlower;

        targetPosition = new Vector3(flowerBottomTransform.position.x, Random.Range(flowerBottomTransform.position.y, flowerTopTransform.position.y), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, targetPosition) > minimumDistance)
        {
            //moves character TO target
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        Vector2 aimDirection = targetPosition - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg-90f;
        rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            walletSystem.insectParts++;
            Destroy(this.gameObject);
            //add 1 insect part to total and dies
        }
        if (collision.tag == "Flower")
        {
            Debug.Log("Flower touchdown");
            StartCoroutine(flowerDamage());
            //touches the flower, waits 5 seconds and lowers the Growth Progress by 10
        }

        
    }
    private IEnumerator flowerDamage()
        {
            yield return new WaitForSeconds(3);
            flowerScript.growthProgress -= 10.0f;
            Destroy(this.gameObject);
            Debug.Log("Insect died and applied 10 damage. Total Growth Progress = " + flowerScript.growthProgress);
        }
}
