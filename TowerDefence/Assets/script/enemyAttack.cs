using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyAttack : MonoBehaviour {



    private int gameOver = 0;

    GameObject point;

    // Use this for initialization

    public GameObject gameOverCanvas;

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            gameOver += 1;
            // Debug.Log("dfdfdfdf");
            //Panel.transform.localScale = new Vector3(1f, 1f, 1f);
            if(gameOver == 1)
            {
                gameOverCanvas.GetComponent<GameOver>().GameOverFunction();
               
            }
            
        }
    }


    // Update is called once per frame
    
}
