using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounterScript : MonoBehaviour {

    public Text ScoreCounter;
    public int point;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPoint()
    {
        point += 1;
        ScoreCounter.text = "Score: " + point;
    }
}
