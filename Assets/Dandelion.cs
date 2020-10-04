using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{

  public  Transform explotion;
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

        if(collision.CompareTag("Ground") == true) {
            Instantiate(explotion, transform.position, transform.rotation );
        GameObject.Destroy(gameObject);
        }

        if (collision.CompareTag("Ground") == true) {
            Instantiate(explotion, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
     //   GameObject.Destroy(gameObject);

    }
}
