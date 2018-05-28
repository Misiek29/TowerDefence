using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{

    public GameObject[] guns;
   


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchWeapon(int gunToActive)
    {
        foreach (var item in guns)
        {
            item.SetActive(false);

        }


        guns[gunToActive].SetActive(true);
    }

}