using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour {

    public bool magnetDetectionEnabled = true;
    int point = 0;
    
    public Text AmmunitionCounter;
    public Image celownik;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce;
    //public int actualGun = 0;

   


    public int actualammunition;

    public int ammunition;

    public GameObject gunSpawner;
    public ParticleSystem muzzleFlash;

    private float timeToNextFire = 0f;
    private float fireRate = 10f;
    // public float impacForce = 50f;


    public GameObject shootEffect;
    public GameObject bloodEffect;
    public Camera fpsCam;
    private GameObject ChangeWeaponObject;

    public bool ammoCounter;
    public bool machineShoot;

    // public GameObject[] guns;



    // Use this for initialization
    void Start() {
        magnetfull.SetEnabled(magnetDetectionEnabled);
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        ChangeWeaponObject = GameObject.Find("Guns");

        actualammunition = ammunition;

      
    }

    // Update is called once per frame
    void Update() {

        if (!magnetDetectionEnabled) return;

        //Input.GetButtonDown("Fire1")
        //magnetfull.CheckIfWasClicked()


        if (actualammunition <= 0)
        {
            reload();
            ChangeWeaponObject.GetComponent<ChangeWeapon>().SwitchWeapon(0);
        }


        if (machineShoot == true)
        {
            if (Input.GetButton("Fire1") && Time.time >= timeToNextFire)
            {
                shoot();
                magnetfull.ResetClick();
                timeToNextFire = Time.time + 1f / fireRate;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shoot();
                magnetfull.ResetClick();
            }
        }
        


            
            ShowAmmo();


    

        // zmiana celownika
        RaycastHit hit2;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range) && hit2.transform.tag == "Enemy")
        {
            celownik.GetComponent<Image>().color = new Color(255, 0, 0, 100);
        }
        else
        {
            //image.transform.localScala = new Vector3(0.2f, 0.2f, 0.2f); 
            celownik.GetComponent<Image>().color = new Color(0, 0, 0, 100);
        }



    }

    public void shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;

        if (ammoCounter == true)
        {
            actualammunition--;
        }

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

                
                actualtarget.Takedamage(damage);

            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (hit.transform.tag == "MachineGun")
            {
                reload();
                ChangeWeaponObject.GetComponent<ChangeWeapon>().SwitchWeapon(1);

                gunSpawner.GetComponent<GunSpawn>().Spawn();
                Destroy(hit.transform.gameObject);


            }

            if (hit.transform.tag == "SniperGun")
            {
                reload();
                ChangeWeaponObject.GetComponent<ChangeWeapon>().SwitchWeapon(2); ;
                
                gunSpawner.GetComponent<GunSpawn>().Spawn();
                Destroy(hit.transform.gameObject);

            }

        }

    }


    public void ShowAmmo()
    {
        if (ammoCounter == false)
        {
            AmmunitionCounter.text = "Ammunition: infinity";
        }
        else
        AmmunitionCounter.text = "Ammunition: " + actualammunition;
    }


    public void GenerateBlood(Vector3 place, Vector3 rotation)
    {
        GameObject BloodObject = Instantiate(bloodEffect, place, Quaternion.LookRotation(rotation));
        DestroyObject(BloodObject, 2.5f);
    }

    public void reload()
    {
        actualammunition = ammunition;
    }

 

    
}
