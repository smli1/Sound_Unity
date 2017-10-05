using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
    
	void Update () {
        if (Camera.main.fieldOfView >= 74)
        {
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(g);
            }
            
        }
	}
}
