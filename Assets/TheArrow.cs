using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheArrow : MonoBehaviour {

    Vector3 upvector;
    public float ArrowSpeed = 5f;
    private void Start() {
        upvector = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector3.up;
    }

    // Update is called once per frame
    void Update() {

        transform.position += upvector * Time.deltaTime * ArrowSpeed;


    }



    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {
            //Do harm
            collision.gameObject.transform.parent.GetComponent<Traveler>().PLZKILLMENOW();

        }


        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

     /*   if (collision.gameObject.CompareTag("Player") == true) {
            //Do harm
            collision.gameObject.transform.parent.GetComponent<Traveler>().PLZKILLMENOW();

        }


        GameObject.Destroy(gameObject);*/
    }
}
