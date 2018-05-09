using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target : MonoBehaviour {

    public float health = 10f;
    public bool gameOver;

    Transform EnemyTarget;
    GameObject player;
    NavMeshAgent agent;
    GameObject tower;




    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyTarget = player.transform;
        agent = GetComponent<NavMeshAgent>();


    }

    public void Update()
    {
       
            agent.SetDestination(EnemyTarget.position);
           
    }

  


    public void Takedamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
           
            Die();
        }
    }

    public void Die()
    {

       
        Destroy(gameObject,0.3f);
        
    }

   






}
