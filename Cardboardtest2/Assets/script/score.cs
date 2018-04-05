using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public int point;
    public Text ScoreCounter;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        
        ScoreCounter.text = point.ToString();
	}

    public void addscore()
    {
        point += 1;
       // ScoreCounter.text = "Score: ";
    }
}
