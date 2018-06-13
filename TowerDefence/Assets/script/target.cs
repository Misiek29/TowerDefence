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
    GameObject PointCounterObject;
    GameObject Armature;

    private bool die = false;
    private bool namierzaj = true;
    private Collider enemyCollider;

    
 

    

    


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Tower");
        EnemyTarget = player.transform;
        agent = GetComponent<NavMeshAgent>();

        PointCounterObject = GameObject.Find("PointCounter");
        Armature = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        enemyCollider = GetComponent<CapsuleCollider>();
        



    }

    public void Update()
    {
       if (namierzaj == true)
        {
            agent.SetDestination(EnemyTarget.position);
        }
           
           
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
        namierzaj = false;
        agent.enabled = false;
        enemyCollider.enabled = false;
        Destroy(gameObject,20f);
        Armature.SetActive(true);
        while(die ==false)
        {
            PointCounterObject.GetComponent<PointCounterScript>().AddPoint();
            die = true;
        }
        

    }

   






}
