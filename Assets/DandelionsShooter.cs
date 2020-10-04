using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionsShooter : MonoBehaviour {


    public Transform projectile;
    public float rechargetime = 1;
    public float firstdelay;

    public float timer;

    Vector3 spawnpoint;

    private void Start() {

        firstdelay = Random.Range(0,3);
        timer -= firstdelay;
        spawnpoint = transform.GetChild(0).transform.position;


    }

    private void Update() {

        timer += Time.deltaTime;

        if (timer >= rechargetime) {
            timer = timer - rechargetime;
            Instantiate(projectile, spawnpoint, transform.rotation, transform);

        }


    }



}
