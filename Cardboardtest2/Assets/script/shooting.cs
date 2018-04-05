using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour {

    public bool magnetDetectionEnabled = true;
    int point = 0;
    public Text ScoreCounter;
    public Image image;

    public float damage = 10f;
    public float range = 100f;

    

    
    
    public Camera fpsCam;
    
    

	// Use this for initialization
	void Start () {
        magnetfull.SetEnabled(magnetDetectionEnabled);
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
       

    }
	
	// Update is called once per frame
	void Update () {

        if (!magnetDetectionEnabled) return;
        //Input.GetButtonDown("Fire1")
        //magnetfull.CheckIfWasClicked()
        if (magnetfull.CheckIfWasClicked())
        {
            shoot();
            magnetfull.ResetClick();
        }
        RaycastHit hit2;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range) && hit2.transform.tag == "Enemy")
        {
            image.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        }
        else
        {
           //image.transform.localScala = new Vector3(0.2f, 0.2f, 0.2f); 
            image.GetComponent<Image>().color = new Color(0, 0, 0, 100);
        }



        }

    public void shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            target actualtarget = hit.transform.GetComponent<target>();
            // m_MyText.text = hit.transform.name;

         

            if (actualtarget != null)
            {
                addpoint();
                actualtarget.Takedamage(damage);
            }
        }

    }

    public void addpoint()
    {
        point += 1;
        ScoreCounter.text = "Score: " + point;
    }

    
}
