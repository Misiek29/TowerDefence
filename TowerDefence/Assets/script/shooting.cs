using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour {

    public bool magnetDetectionEnabled = true;
    int point = 0;
    public Text ScoreCounter;
    public Text AmmunitionCounter;
    public Image image;

    public float damage = 10f;
    public float range = 100f;
    public int actualGun = 0;


    public int ammunition;

    public GameObject gunSpawner;

    private float timeToNextFire = 0f;
    private float fireRate = 10f;
    // public float impacForce = 50f;


    public GameObject shootEffect;
    public GameObject bloodEffect;
    public Camera fpsCam;

    public GameObject[] guns;



    // Use this for initialization
    void Start() {
        magnetfull.SetEnabled(magnetDetectionEnabled);
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update() {

        if (!magnetDetectionEnabled) return;

        //Input.GetButtonDown("Fire1")
        //magnetfull.CheckIfWasClicked()

        if (ammunition <= 0)
        {
            actualGun = 0;
        }

        switch (actualGun)
        {

            case 0:

                ChangeWeapon(0);
                damage = 10;
                range = 12;
                ammunition = 10;
                if (Input.GetButtonDown("Fire1"))
                {
                    shoot();
                    magnetfull.ResetClick();
                }
                break;


            case 1:
                ChangeWeapon(1);
                damage = 10;
                range = 18;

                if (Input.GetButton("Fire1") && Time.time >= timeToNextFire)
                {
                    shoot();
                    magnetfull.ResetClick();
                    timeToNextFire = Time.time + 1f / fireRate;
                }
                break;

            case 2:

                ChangeWeapon(2);
                damage = 50;
                range = 100;

                if (Input.GetButtonDown("Fire1"))
                {
                    shoot();
                    magnetfull.ResetClick();

                }
                break;


               

        }

        ShowAmmo();




        // zmiana celownika
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
       
        ammunition--;

        


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            target actualtarget = hit.transform.GetComponent<target>();
            // m_MyText.text = hit.transform.name;

            GameObject ImpactObject = Instantiate(shootEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactObject, 2f);

            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * impacForce);
            //}

            if (actualtarget != null)
            {
                GenerateBlood(hit.point, hit.normal);

                addpoint();
                actualtarget.Takedamage(damage);

            }

            if (hit.transform.tag == "MachineGun")
            {

                actualGun = 1;
                ammunition = 33;
                
                gunSpawner.GetComponent<GunSpawn>().Spawn();
                Destroy(hit.transform.gameObject);


            }

            if (hit.transform.tag == "SniperGun")
            {
                actualGun = 2;
                ammunition = 10;
                
                gunSpawner.GetComponent<GunSpawn>().Spawn();
                Destroy(hit.transform.gameObject);

            }


        }


    }

    public void addpoint()
    {
        point += 1;
        ScoreCounter.text = "Score: " + point;

    }

    public void ShowAmmo()
    {
        if (actualGun == 0)
        {
            AmmunitionCounter.text = "Ammunition: infinity";
        }
        else
        AmmunitionCounter.text = "Ammunition: " + ammunition;
    }


    public void GenerateBlood(Vector3 place, Vector3 rotation)
    {
        GameObject BloodObject = Instantiate(bloodEffect, place, Quaternion.LookRotation(rotation));
        DestroyObject(BloodObject, 1f);
    }

    public void ChangeWeapon(int gunToActive)
    {
        foreach (var item in guns)
        {
            item.SetActive(false);

        }

        guns[gunToActive].SetActive(true);
    }

    
}
