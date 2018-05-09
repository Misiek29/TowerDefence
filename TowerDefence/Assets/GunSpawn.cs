using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour {

    public GameObject[] guns;
    public float timeSpawn;
    public Transform[] spawnPoints;
    public bool keepSpawning = true;


    public GameObject[] spawnGuns;



    // Use this for initialization
    void Start()
    {


        // InvokeRepeating("Spawn", timeSpawn, timeSpawn);

        Spawn();

    }

    // Update is called once per frame
    void Update()
    {
      


    }



    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {

      
         

            yield return new WaitForSeconds(secondsBetweenSpawns);

        // Now it's time to spawn again.
        int SpawnPointIndex = Random.Range(0, spawnPoints.Length);
        int SpawnGunIndex = Random.Range(0, guns.Length);

        Instantiate(guns[SpawnGunIndex], spawnPoints[SpawnPointIndex].position, spawnPoints[SpawnPointIndex].rotation);

    }

    public void Spawn()
    {

        StartCoroutine(SpawnAtIntervals(timeSpawn));



    }



 }

