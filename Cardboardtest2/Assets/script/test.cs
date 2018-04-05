using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject obiekt;
    // Use this for initialization

    // public GameObject[] cele;
    
    
    public void rozwal(GameObject obiektDoZniszczenia)
    {
        if (controlmagnetic.niszczenie)
        {
            controlmagnetic.niszczenie = false;
            controlmagnetic.nacelowanie = false;
            Destroy(obiektDoZniszczenia);
            
        }
    }


  

}
