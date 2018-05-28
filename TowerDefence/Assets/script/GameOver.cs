using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Image gameOverImage;
    public GameObject gameOverUi;

    public GameObject PointCounter;
    public Text scoreFinishText;

    // private PointCounterScript PointCounterScriptValue;
    private bool gameOver = false;
    private int pointFinish;

    

	// Use this for initialization
	void Start () {

        


	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver == true & Input.GetButtonDown("Fire1"))
        {
            //Application.LoadLevel("test");

            SceneManager.LoadScene(0);
        }
	}

    public void GameOverFunction()
    {

        gameOver = true;

        pointFinish = PointCounter.GetComponent<PointCounterScript>().point;

        StartCoroutine(Fade(Color.clear, Color.black, 1));
        gameOverUi.SetActive(true);

        scoreFinishText.text = "Score: " + pointFinish;


    }

    IEnumerator Fade(Color from, Color to, float time)
    {
        float speed = 0.7f / time;
        float percent = 0;

        while (percent <1)
        {
            percent += Time.deltaTime * speed;
            gameOverImage.color = Color.Lerp(from, to, percent);
            yield return null;

        }

    }

}
