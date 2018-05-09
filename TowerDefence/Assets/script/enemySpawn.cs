using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {

    public GameObject enemy;
    public float timeSpawn = 5f;
    public Transform[] spawnPoints;
    public bool keepSpawning = true;
    int enemyNumber;

    int enemyCount;


	// Use this for initialization
	void Start () {

        enemyNumber = 2;
        // InvokeRepeating("Spawn", timeSpawn, timeSpawn);

        StartCoroutine(SpawnAtIntervals(timeSpawn));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {
       
        while (keepSpawning)
        {
            if (enemyCount == 5)
            {
                secondsBetweenSpawns = 4;
                enemyNumber = 2;
            }

            if (enemyCount == 10)
            {
                secondsBetweenSpawns = 3;
                enemyNumber = 3;
            }

            if (enemyCount == 20)
            {
                secondsBetweenSpawns = 2;
                enemyNumber = 4;
            }

            if (enemyCount == 30)
            {
                secondsBetweenSpawns = 1;
                enemyNumber = 6;
            }

            if (enemyCount == 40)
            {
                secondsBetweenSpawns = 1;
                enemyNumber = 7;
            }

            yield return new WaitForSeconds(secondsBetweenSpawns);

            // Now it's time to spawn again.
            Spawn();
        }
    }

    public void Spawn()
    {

        enemyCount++;

        for (int i = 0; i < enemyNumber; i++)
        {
            int SpawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy, spawnPoints[SpawnPointIndex].position, spawnPoints[SpawnPointIndex].rotation);
        }
        

       
    }

  
}
