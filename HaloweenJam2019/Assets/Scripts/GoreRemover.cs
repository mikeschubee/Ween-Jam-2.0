using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreRemover : MonoBehaviour
{
    
    void Start()
    {
        Invoke("KillMe", 5);
    }
    void KillMe()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
