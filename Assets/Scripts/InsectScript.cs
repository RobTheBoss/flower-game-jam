using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InsectScript : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] float minimumDistance;

    private GameManager walletSystem;
    private FlowerScript flowerScript;

    public Transform target;
    private Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("FlowerPlaceholder").transform;
        walletSystem = GameObject.Find("GameManager").GetComponent<GameManager>();
        flowerScript = GameObject.Find("FlowerPlaceholder").GetComponent<FlowerScript>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            //moves character TO target
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        Vector2 aimDirection = target.position - transform.position;
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
            new WaitForSeconds(5);
            flowerScript.growthProgress -= -10.0f;
            Destroy(this.gameObject);
            //touches the flower, waits 5 seconds and lowers the Growth Progress by 10
        }
    }
}
