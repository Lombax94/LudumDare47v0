using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{
    Rigidbody2D body;
    Vector3 direction = Vector3.zero;

    public float forceapply = 1;
    bool grounded = false;

    public Vector3 gravytea = Vector3.down;
    Vector3 gravy;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded == true) {

       transform.position += (direction * forceapply * Time.deltaTime);
        } else {
            gravy += (gravytea * Time.deltaTime * 0.25f);
            transform.position += (direction * forceapply * Time.deltaTime) + gravy;

        }
        transform.Rotate(Vector3.back, ((360 * Time.deltaTime * forceapply / 3.14f)  ));

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        grounded = true;
        gravy = Vector3.zero;
        direction = (Quaternion.Euler(0, 0, -90) * collision.contacts[0].normal).normalized;
        gravytea = Quaternion.Euler(0, 0, 180) * collision.contacts[0].normal;
        //    GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-90) * collision.contacts[0].normal);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        grounded = true;
    }

}
