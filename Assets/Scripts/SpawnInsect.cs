using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnInsect : MonoBehaviour
{
    public GameObject InsectPrefab;
    public float minTime, maxTime;
    private float timeBetweenInsectSpawn;
    private float spawnInsectTime;
    public bool canSpawn = false;


    // Update is called once per frame
    void Update()
    {   
        if (canSpawn && Time.time > spawnInsectTime )
        {
            float randomY = UnityEngine.Random.Range(4.0f, -4.0f);
            Instantiate(InsectPrefab, transform.position + new Vector3(5, randomY, 0), transform.rotation);
            timeBetweenInsectSpawn = UnityEngine.Random.Range(minTime, maxTime);
            spawnInsectTime = Time.time + timeBetweenInsectSpawn;
            Debug.Log(timeBetweenInsectSpawn);
        }   
    }
}




