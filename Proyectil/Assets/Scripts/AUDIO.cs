using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO : MonoBehaviour
{
    public AudioSource golpe;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            if (!golpe.isPlaying)
            {
                golpe.Play();
            }
            Debug.Log("GOLPE");
           
        } 
        
    }
}
