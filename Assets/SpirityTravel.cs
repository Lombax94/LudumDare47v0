using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpirityTravel : MonoBehaviour {

    float timetotravel = 3f;
    float counter = 0;

    bool fade = false;
    SpriteRenderer me;
    private void Start() {
        me = GetComponent<SpriteRenderer>();

        travelvector = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector3.up;
    }
   public Vector3 travelvector;
    // Update is called once per frame
    void Update()
    {

        transform.position += travelvector * Time.deltaTime;

        if(fade == false) {

        counter += Time.deltaTime;

        if (counter >= timetotravel) {
            GameObject.Find("Traveler").GetComponent<Traveler>().startfadetoblack = true;
                fade = true;
        }

        } else {

                me.color = new Color(me.color.r, me.color.g, me.color.b, me.color.a - (Time.deltaTime / 2f));
            if(me.color.a <= 0) {
                GameObject.Destroy(gameObject);
            }


        }

    }
}
