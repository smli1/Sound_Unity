using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyO : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(d(5));
    }

    IEnumerator d(float time)
    {
        Color a = GetComponent<MeshRenderer>().material.color;
        while(a.a >= 0.01f) {
            yield return new WaitForSeconds(0.01f);            
            a.a = Mathf.Lerp(a.a,0,0.01f);
            GetComponent<MeshRenderer>().material.color = a;
        }
        Destroy(gameObject);
    }
}
