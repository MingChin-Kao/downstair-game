using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class audioScript : MonoBehaviour
{

	public AudioClip impact;
    AudioSource audiosource;
    
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("player")){
            audiosource.PlayOneShot(impact);
        }
    }

   
}


