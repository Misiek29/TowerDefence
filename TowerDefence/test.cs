using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    // Use this for initialization

    public GameObject[] cele;
	public void hide()
    {
       // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
       // cube.transform.position = new Vector3(2, 2, 0);
        Destroy(gameObject);
    }
}
