using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{

    AnimatorManager _AnimatorManager;
    SpriteRenderer _SpriteRenderer;

    Rigidbody2D body;
    public bool Grounded = false;
    public float Gravitydrag = 0.1f;
    public float Speedcap = 10;

    Vector3 UpVector = Vector3.zero;

    Vector3 _Gravydirection = Vector3.down;
    Vector3 _Rollingdirection = Vector3.zero;
    Vector3 _Fallingdirection = Vector3.zero;
    Vector3 _Gravypull;
    public Vector3 _Rollingdirectionspeed = Vector3.zero;

    Transform _Cam;
  public  float _Speed = 0;
    public float rotationspeed = 0;
    public float camrotatespeed = 1;
    float camrotateValue = 0;
   public float fallingspeed = 0;

    void Start() {
        _Cam = GameObject.Find("Main Camera").transform;
        body = transform.GetComponent<Rigidbody2D>();
        _AnimatorManager = GetComponent<AnimatorManager>();
        _SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _AnimatorManager.Animator.speed = 0;
        UpVector = Vector3.up;
    }

    

    void Update() {

        if (Grounded == true) {

            if (Input.GetKey(KeyCode.Space) == true) {
                _AnimatorManager.ChargeJump(true);
                _AnimatorManager.Animator.speed = 1;

                if (_Speed > 0) {
                    _Speed -= Time.deltaTime * ((Speedcap - (Speedcap - _Speed)) *1);

                    if (_Speed < 0.05f) {
                        _Speed = 0;

                    }

                } else if (_Speed < 0) {
                    _Speed += Time.deltaTime * ((Speedcap - (Speedcap + _Speed)) * 1);

                    if (_Speed > -0.05f) {
                        _Speed = 0;

                    }

                }

            }
            if (Input.GetKeyUp(KeyCode.Space) == true) {
                _AnimatorManager.ChargeJump(false);
           //     _Fallingdirection += UpVector * 0.2f;
                fallingspeed = 0.4f;
                Grounded = false;
                _AnimatorManager.Animator.speed = 1;
                Debug.Log("SENDING THE FROM TO SPACE");
            }



            if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.Space) == false) {

                if (_Speed >= Speedcap) {
                    _Speed = Speedcap;

                } else if (_Speed < 0) {  //Break

                    _Speed += Time.deltaTime * (Speedcap - _Speed);

                    if (_Speed > 0) {
                        _SpriteRenderer.flipX = false;
                        _AnimatorManager.Slide(false);
                    } else {
                        _SpriteRenderer.flipX = true;
                        _AnimatorManager.Slide(true);

                    }

                } else if (_Speed < Speedcap) {
                    _Speed += Time.deltaTime * (Speedcap - _Speed) * 5;

                    if (_Speed > Speedcap) {
                        _Speed = Speedcap;
                        _AnimatorManager.Animator.speed = Speedcap;

                    } else {
                        _AnimatorManager.Animator.speed = _Speed;

                    }

                }

            } else if (Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.Space) == false) {

                if (_Speed <= -Speedcap) {
                    _Speed = -Speedcap;

                } else if (_Speed > 0) {  //Break
                    _Speed -= Time.deltaTime * (Speedcap + _Speed);

                    if (_Speed < 0) {
                        _SpriteRenderer.flipX = true;
                        _AnimatorManager.Slide(false);
                    } else {
                        _SpriteRenderer.flipX = false;
                        _AnimatorManager.Slide(true);

                    }

                } else if (_Speed > -Speedcap) {
                    _Speed -= Time.deltaTime * (Speedcap + _Speed) * 5;

                    if (_Speed < -Speedcap) {
                        _Speed = -Speedcap;
                        _AnimatorManager.Animator.speed = Speedcap;

                    } else {
                        _AnimatorManager.Animator.speed = -_Speed;

                    }

                }


            } else if(Input.GetKey(KeyCode.Space) == false) {// Idle Running. slowing player down to 0 speed

                if (_Speed > 0) {
                    _AnimatorManager.Slide(false);
                    _Speed -= Time.deltaTime * ((Speedcap - (Speedcap - _Speed)) * 0.75f);

                    if (_Speed < 0) {
                        _Speed = 0;

                    }
                    _AnimatorManager.Animator.speed = _Speed;

                } else if (_Speed < 0) {
                    _AnimatorManager.Slide(false);
                    _Speed += Time.deltaTime * ((Speedcap - (Speedcap + _Speed)) * 0.75f);

                    if (_Speed > 0) {
                        _Speed = 0;

                    }
                    _AnimatorManager.Animator.speed = -_Speed;

                }

            }

            if(fallingspeed != 0) {
                _AnimatorManager.InAir(true);
                body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + (UpVector * fallingspeed));
            } else {

            _Rollingdirectionspeed = _Rollingdirection * _Speed;
            body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + _Fallingdirection * Time.deltaTime);
            }

        } else {


            if (fallingspeed < 0) {
                _AnimatorManager.Falling(true);

                fallingspeed -= Time.deltaTime * Gravitydrag * 1.5f;
            } else {
                fallingspeed -= Time.deltaTime * Gravitydrag;

            }

            //  _Fallingdirection += (_Gravydirection * Time.deltaTime * Gravitydrag);
            body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + (UpVector * fallingspeed));

        }




       _Cam.position = transform.position + Vector3.back;
        //Doesnt work. wanted to make an offset but because the player snap rotates, the camera will also snap which make a realy bad visual effect. might look into this later if i got time. but not needed works fine as is
        //   _Cam.position = Vector3.MoveTowards(_Cam.position, transform.position + Vector3.back + (Quaternion.Euler(0,0, transform.eulerAngles.z) * Vector2.up * 4.5f), 0.1f);


        if (camrotateValue < camrotatespeed) {
            camrotateValue += rotationspeed * Time.deltaTime;
            if (camrotateValue >= camrotatespeed) {
                camrotateValue = camrotatespeed;

            }
            _Cam.rotation = Quaternion.RotateTowards(_Cam.rotation, transform.rotation, camrotateValue);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.CompareTag("Ground")) {
            Grounded = true;

            fallingspeed = 0;
            _Fallingdirection = Vector3.zero;
            _Gravypull = Vector3.zero;

            for (int i = 0; i < collision.contactCount; i++) {
                if (collision.collider.CompareTag("Ground")) {
                    if (collision.contacts[0].normal != (Vector2)(Quaternion.Euler(0, 0, collision.contacts[0].collider.transform.eulerAngles.z) * Vector3.up)) {
                        Debug.Log("WRONG, not hitting top of collider, code abit nasty buuuut time is flowing faster then sand is falling");

                    } else {

                        _Fallingdirection = Vector3.zero;
                        UpVector = collision.contacts[0].normal.normalized;
                        _Rollingdirection = (Quaternion.Euler(0, 0, -90) * collision.contacts[0].normal).normalized;
                        _Gravydirection = (Quaternion.Euler(0, 0, 180) * collision.contacts[0].normal).normalized;

                        transform.eulerAngles = collision.contacts[0].collider.transform.eulerAngles;
                        rotationspeed = 1 * (Quaternion.Angle(_Cam.rotation, transform.rotation)) * 0.1f;
                        camrotateValue = 0;
                        camrotatespeed = (Quaternion.Angle(_Cam.rotation, transform.rotation));
                        _AnimatorManager.InAir(false);
                        _AnimatorManager.Falling(false);

                    }
                    return;

                }

            }

        }

    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")) {
            _AnimatorManager.InAir(false);
            _AnimatorManager.Falling(false);

            Grounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
            if (collision.collider.CompareTag("Ground")) {
                _AnimatorManager.InAir(true);
                _AnimatorManager.Falling(true);
            Grounded = false;
            }

    }

}
