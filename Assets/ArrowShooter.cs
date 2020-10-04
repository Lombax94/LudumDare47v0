using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour {

    public Transform projectile;
    public float rechargetime = 1;
    public float firstdelay;
    public AudioClip test;
    AudioSource test1;

  public  float timer;

    Vector3 spawnpoint;
    
    private void Start() {

        timer -= firstdelay;
        spawnpoint = transform.GetChild(0).transform.position;
        test1 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    private void Update() {

        timer += Time.deltaTime;

        if(timer >= rechargetime) {
            timer = timer - rechargetime;
            Instantiate(projectile, spawnpoint, transform.rotation , transform);
         //   test1.clip = test;
         //   test1.Play(); yea nope
        }


    }



}
