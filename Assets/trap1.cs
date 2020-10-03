using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class trap1 : MonoBehaviour
{

	public AudioClip impact;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

	private void OnCollisionEnter2D(Collision2D other){
		
		if(other.gameObject.CompareTag("player")){
			playerController.isDead = true;
			audiosource.PlayOneShot(impact);
		}

	}

}





