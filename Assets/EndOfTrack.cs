using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTrack : MonoBehaviour
{

    bool disable = false;
    BoxCollider2D colli;
    AudioSource test1;
   public AudioClip test; 

    float counter = 0;

    private void Start() {
        colli = GetComponent<BoxCollider2D>();
        test1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

    }
    private void Update() {
        
        if(disable == true) {

            counter += Time.deltaTime;

            if(counter >= 10) {
                colli.enabled = true;
                disable = false;
                counter = 0;
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        colli.enabled = false; 
         disable = true;
        test1.clip = test;
        test1.Play();
        collision.gameObject.transform.parent.GetComponent<Traveler>().PLZKILLMESlowly();

    }

}
