using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyAttack : MonoBehaviour {

    GameObject Panel;
    
    GameObject tower;

    // Use this for initialization

    private void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");
        Panel = GameObject.FindGameObjectWithTag("GameOver");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Tower")
        {
           // Debug.Log("dfdfdfdf");
            Panel.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }


    // Update is called once per frame
    
}
