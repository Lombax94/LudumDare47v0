using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionExplotion : MonoBehaviour
{

    private void Update() {
     //   GameObject.Destroy(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {
            //Do harm
            collision.gameObject.transform.parent.GetComponent<Traveler>().PLZKILLMENOW();

        }

    }

    public void SelfExplode() {
        GameObject.Destroy(transform.parent.gameObject);
    }

}
