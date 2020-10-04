using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traveler : MonoBehaviour {

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
    public float _Speed = 0;
    public float rotationspeed = 0;
    public float camrotatespeed = 1;
    float camrotateValue = 0;
    public float fallingspeed = 0;

    public SpriteRenderer FadeToBlack;
    public Transform Ghost;
    public Transform Stone;
    Transform HealthPoint;
    bool fadetoblack = false;
    bool fadetowhite = false;

    public AudioClip test;
    public AudioSource test1;

    public void PLZKILLMENOW() {
        fadetoblack = true;

    }
public void PLZKILLMESlowly() {
        fadetowhite = true;
        startfadetoblack = true;
    }
    void Start() {

        startpos = transform.position;
        _Cam = GameObject.Find("Main Camera").transform;
        body = transform.GetComponent<Rigidbody2D>();
        _AnimatorManager = GetComponentInChildren<AnimatorManager>();
        _SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        HealthPoint = GameObject.FindGameObjectWithTag("MyHealth").transform;
        _AnimatorManager.Animator.speed = 1;
        test1 = _Cam.GetComponent<AudioSource>();
        _AnimatorManager.InAir(true);
        _AnimatorManager.Falling(true);

        _Gravydirection = Vector3.left;
        UpVector = Vector3.right;
        startrotation = transform.rotation;
    }

    Vector3 startpos;

    bool spawnondeath = false;
    public bool startfadetoblack = false;
    bool reversefadetoblack = false;
    Vector3 lastgroundposition ;
    Quaternion startrotation;

    void Update() {
        if (fadetowhite == true) {








        /*    if (spawnondeath == false) {
                spawnondeath = true;

                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                HealthPoint.GetComponent<Image>().color = Color.red;
                Instantiate(Stone, lastgroundposition, transform.rotation);
                Instantiate(Ghost, transform.position, transform.rotation);
                //   startfadetoblack = true;
            }*/

            if (startfadetoblack == true) {
                FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a + (Time.deltaTime / 5f));

                if (FadeToBlack.color.a >= 1) {
                    FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a + 0.5f);
                    reversefadetoblack = true;
                    startfadetoblack = false;
                    transform.position = startpos;
                    _Cam.position = transform.position + Vector3.back;
                    _AnimatorManager.InAir(false);
                    Grounded = false;
                    transform.rotation = startrotation;
                    _Cam.rotation = transform.rotation;
                }

            }

            if (reversefadetoblack == true) {
                FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a - (Time.deltaTime / 2f));

                if (FadeToBlack.color.a <= 0) {
                    reversefadetoblack = false;
                    transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    HealthPoint.GetComponent<Image>().color = Color.white;
                    fadetoblack = false;
                    spawnondeath = false;



                    onplatformground = false;
                    ground1 = null;
                    ground2 = null;
                    _Speed = 0;
                    fallingspeed = 0;
                    _Fallingdirection = Vector3.zero;
                    _Gravypull = Vector3.zero;

                    _Rollingdirection = Vector3.zero;
                    _Rollingdirectionspeed = Vector3.zero;

                    _AnimatorManager.Speed(0);
                    _AnimatorManager.JumpImpacts(0);

                    _AnimatorManager.InAir(true);
                    _AnimatorManager.Falling(true);
                    _AnimatorManager.Slide(false);

                    _Gravydirection = Vector3.left;
                    UpVector = Vector3.right;
                    fadetowhite = false;


                }
            }























        } else if (fadetoblack == true) {

            if (spawnondeath == false) {
                spawnondeath = true;

                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                HealthPoint.GetComponent<Image>().color = Color.red;
                Instantiate(Stone, lastgroundposition, transform.rotation);
                Instantiate(Ghost, transform.position, transform.rotation);
             //   startfadetoblack = true;
            }

            if(startfadetoblack == true) {
                FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a + (Time.deltaTime / 5f));

                if (FadeToBlack.color.a >= 1) {
                    FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a + 0.5f);
                    reversefadetoblack = true;
                    startfadetoblack = false;
                    transform.position = startpos;
                    _Cam.position = transform.position + Vector3.back;
                    _AnimatorManager.InAir(false);
                    Grounded = false;
                    transform.rotation = startrotation;
                    _Cam.rotation = transform.rotation;
                }

            }

            if(reversefadetoblack == true) {
                FadeToBlack.color = new Color(FadeToBlack.color.r, FadeToBlack.color.g, FadeToBlack.color.b, FadeToBlack.color.a - (Time.deltaTime / 2f));

                if (FadeToBlack.color.a <= 0) {
                    reversefadetoblack = false;
                    transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    HealthPoint.GetComponent<Image>().color = Color.white;
                    fadetoblack = false;
                    spawnondeath = false;



                    onplatformground = false;
                    ground1 = null;
                    ground2 = null;
                    _Speed = 0;
                    fallingspeed = 0;
                    _Fallingdirection = Vector3.zero;
                    _Gravypull = Vector3.zero;

                    _Rollingdirection = Vector3.zero;
                    _Rollingdirectionspeed = Vector3.zero;

                    _AnimatorManager.Speed(0);
                    _AnimatorManager.JumpImpacts(0);

                    _AnimatorManager.InAir(true);
                    _AnimatorManager.Falling(true);
                    _AnimatorManager.Slide(false);

                    _Gravydirection = Vector3.left;
                    UpVector = Vector3.right;

           

                }
            }


        } else {




            if (Grounded == true) {
                lastgroundposition = transform.position;

                if (_AnimatorManager.TheJumpImpact == false) {

                    if (Input.GetKey(KeyCode.Space) == true) {
                        _AnimatorManager.ChargeJump(true);
                        //   _AnimatorManager.Animator.speed = 1;

                        if (_Speed > 0) {
                            _Speed -= Time.deltaTime * ((Speedcap - (_Speed - 0.3f)) * 4f);

                            if (_Speed < 0.05f) {
                                _Speed = 0;

                            }

                        } else if (_Speed < 0) {
                            _Speed += Time.deltaTime * ((Speedcap + (_Speed + 0.13f)) * 4f);

                            if (_Speed > -0.05f) {
                                _Speed = 0;

                            }

                        }

                        if (Input.GetKey(KeyCode.RightArrow) == true) {
                            _SpriteRenderer.flipX = false;

                        }

                        if (Input.GetKey(KeyCode.LeftArrow) == true) {
                            _SpriteRenderer.flipX = true;

                        }


                    }
                    if (Input.GetKeyUp(KeyCode.Space) == true) {
                        _AnimatorManager.ChargeJump(false);

                        //     _Fallingdirection += UpVector * 0.2f;


                        fallingspeed = 0.5f * Mathf.Abs(_Speed) / Speedcap;
                        if (fallingspeed <= 0.35f) {
                            fallingspeed = 0.35f;
                        } else if (fallingspeed >= 0.5f)
                            fallingspeed = 0.65f;

                        

                        Grounded = false;
                        //     _AnimatorManager.Animator.speed = 1;
                        //            Debug.Log("SENDING THE FROM TO SPACE");


                        if (Input.GetKey(KeyCode.RightArrow) == true) {
                            _Speed = Speedcap;
                            _Rollingdirectionspeed = _Rollingdirection * _Speed;

                        }

                        if (Input.GetKey(KeyCode.LeftArrow) == true) {
                            _Speed = -Speedcap;
                            _Rollingdirectionspeed = _Rollingdirection * _Speed;


                        }
                        test1.clip = test;
                        test1.Play();


                    }



                    if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.Space) == false) {

                        if (_Speed >= Speedcap) {
                            _SpriteRenderer.flipX = false;
                            _AnimatorManager.Slide(false);

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

                        } else if (_Speed >= 0) {
                            _Speed += Time.deltaTime * (Speedcap - _Speed) * 5;
                            _SpriteRenderer.flipX = false;
                            _AnimatorManager.Slide(false);

                            if (_Speed > Speedcap) {
                                _Speed = Speedcap;
                                //       _AnimatorManager.Animator.speed = Speedcap;

                            } else {
                                //       _AnimatorManager.Animator.speed = _Speed;

                            }

                        }

                    } else if (Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.Space) == false) {

                        if (_Speed <= -Speedcap) {
                            _SpriteRenderer.flipX = true;
                            _Speed = -Speedcap;
                            _AnimatorManager.Slide(false);

                        } else if (_Speed > 0) {  //Break
                            _Speed -= Time.deltaTime * (Speedcap + _Speed);

                            if (_Speed < 0) {
                                _SpriteRenderer.flipX = true;
                                _AnimatorManager.Slide(false);
                            } else {
                                _SpriteRenderer.flipX = false;
                                _AnimatorManager.Slide(true);

                            }

                        } else if (_Speed <= 0) {
                            _Speed -= Time.deltaTime * (Speedcap + _Speed) * 5;
                            _SpriteRenderer.flipX = true;
                            _AnimatorManager.Slide(false);

                            if (_Speed < -Speedcap) {
                                _Speed = -Speedcap;
                                //          _AnimatorManager.Animator.speed = Speedcap;

                            } else {
                                //         _AnimatorManager.Animator.speed = -_Speed;

                            }

                        }


                    } else if (Input.GetKey(KeyCode.Space) == false) {// Idle Running. slowing player down to 0 speed

                        if (_Speed > 0) {
                            _AnimatorManager.Slide(false);
                            _Speed -= Time.deltaTime * ((Speedcap - (Speedcap - _Speed)) * 0.75f);

                            if (_Speed < 0) {
                                _Speed = 0;

                            }
                            //        _AnimatorManager.Animator.speed = _Speed;

                        } else if (_Speed < 0) {
                            _AnimatorManager.Slide(false);
                            _Speed += Time.deltaTime * ((Speedcap - (Speedcap + _Speed)) * 0.75f);

                            if (_Speed > 0) {
                                _Speed = 0;

                            }
                            //        _AnimatorManager.Animator.speed = -_Speed;

                        }

                    }

                    if (fallingspeed != 0) {

                        if (fallingspeed < 0) {
                            _AnimatorManager.Falling(true);

                        }

                        _AnimatorManager.InAir(true);
                        _AnimatorManager.Speed(Mathf.Abs(_Speed));
                        body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + (UpVector * fallingspeed));
                    } else {

                        _Rollingdirectionspeed = _Rollingdirection * _Speed;
                        _AnimatorManager.Speed(Mathf.Abs(_Speed));
                        body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + _Fallingdirection * Time.deltaTime);
                    }

                } else {
                    //         Debug.Log("That Jump Made My Tongue Come Out My Butt");

                }

            } else {
                _AnimatorManager.Falling(true);
                _AnimatorManager.InAir(true);
                _AnimatorManager.ChargeJump(false);
                Grounded = false;

                if (fallingspeed < 0) {


                    fallingspeed -= Time.deltaTime * Gravitydrag * 1.5f;
                } else {
                    fallingspeed -= Time.deltaTime * Gravitydrag;

                }

                //  _Fallingdirection += (_Gravydirection * Time.deltaTime * Gravitydrag);
                _AnimatorManager.Speed(Mathf.Abs(_Speed));
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

    }

    float anglesaver = 0;
    bool onplatformground = false;
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.CompareTag("GameController")) {
            lastgroundposition = transform.position;
            PLZKILLMENOW();
            return;
        }


            if (collision.collider.CompareTag("Wall")) {
            for (int i = 0; i < collision.contactCount; i++) {
                if (collision.contacts[i].collider.gameObject == collision.collider.gameObject) {
                    if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up)) {

                        if (ground1 == null) {
                            ground1 = collision.gameObject;
                        } else if (ground2 == null) {
                            ground2 = collision.gameObject;
                        }

                        UpVector = collision.contacts[i].normal.normalized;
                        _Rollingdirection = (Quaternion.Euler(0, 0, -90) * collision.contacts[i].normal).normalized;
                        _Gravydirection = (Quaternion.Euler(0, 0, 180) * collision.contacts[i].normal).normalized;
                        transform.eulerAngles = collision.contacts[i].collider.transform.eulerAngles;
                        rotationspeed = 1 * (Quaternion.Angle(_Cam.rotation, transform.rotation)) * 0.05f;
                        camrotateValue = 0;
                        camrotatespeed = (Quaternion.Angle(_Cam.rotation, transform.rotation));


                        if (Grounded == false) {
                            onplatformground = true;
                                Grounded = true;
                            _Speed = 0;
                            fallingspeed = 0;
                            _Fallingdirection = Vector3.zero;
                            _Gravypull = Vector3.zero;

                            _Rollingdirectionspeed = _Rollingdirection * _Speed;

                            _AnimatorManager.Falling(false);
                            _AnimatorManager.InAir(false);
                            _AnimatorManager.Speed(_Speed);
                            _AnimatorManager.JumpImpacts(0);

                        }

                    } 
                    break;

                }

            }




      /*      for (int i = 0; i < collision.contactCount; i++) {

                if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up)) {
                    Debug.Log("Topside");
                    onplatformground = true;
                    if (Grounded == false) {
                        _Speed = 0;
                        _Rollingdirectionspeed = _Rollingdirection * _Speed;
                    }

                    fallingspeed = 0;
                    _Gravypull = Vector3.zero;

                    _Fallingdirection = Vector3.zero;
                    UpVector = collision.contacts[i].normal.normalized;
                    _Rollingdirection = (Quaternion.Euler(0, 0, -90) * collision.contacts[i].normal).normalized;
                    _Gravydirection = (Quaternion.Euler(0, 0, 180) * collision.contacts[i].normal).normalized;

                    transform.eulerAngles = collision.contacts[i].collider.transform.eulerAngles;
                    rotationspeed = 1 * (Quaternion.Angle(_Cam.rotation, transform.rotation)) * 0.05f;
                    camrotateValue = 0;
                    camrotatespeed = (Quaternion.Angle(_Cam.rotation, transform.rotation));
                    _AnimatorManager.InAir(false);
                    _AnimatorManager.Falling(false);
                    Grounded = true;
                    break;

                } else {


                    //        Debug.Log(collision.contacts[i].normal + "   Topside  " + (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up));
                }

                if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z - 90) * Vector3.up)) {
                    //        Debug.Log("Rightside");
                } else {
                    //        Debug.Log(collision.contacts[i].normal + "   Rightside  " + (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z - 90) * Vector3.up));
                }
                if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z + 90) * Vector3.up)) {
                    //         Debug.Log("LeftSide");
                } else {
                    //         Debug.Log(collision.contacts[i].normal + "   LeftSide  " + (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z + 90) * Vector3.up));

                }
                if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z + 180) * Vector3.up)) {
                    //         Debug.Log("Buttside");

                } else {
                    //          Debug.Log(collision.contacts[i].normal + "   Buttside  " + (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z + 180) * Vector3.up));

                }

            }*/

        }


        

        if (collision.collider.CompareTag("Ground")) {
            for (int i = 0; i < collision.contactCount; i++) {
                if(collision.contacts[i].collider.gameObject == collision.collider.gameObject) {
                    if (collision.contacts[i].normal == (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up)) {

                        if (ground1 == null) {
                            ground1 = collision.gameObject;
                        } else if (ground2 == null) {
                            ground2 = collision.gameObject;
                        }
                        
                            UpVector = collision.contacts[i].normal.normalized;
                        _Rollingdirection = (Quaternion.Euler(0, 0, -90) * collision.contacts[i].normal).normalized;
                        _Gravydirection = (Quaternion.Euler(0, 0, 180) * collision.contacts[i].normal).normalized;
                        transform.eulerAngles = collision.contacts[i].collider.transform.eulerAngles;
                        rotationspeed = 1 * (Quaternion.Angle(_Cam.rotation, transform.rotation)) * 0.05f;
                        camrotateValue = 0;
                        camrotatespeed = (Quaternion.Angle(_Cam.rotation, transform.rotation));


                        if (Grounded == false) {
                            Grounded = true;
                            _Speed = 0;
                            fallingspeed = 0;
                            _Fallingdirection = Vector3.zero;
                            _Gravypull = Vector3.zero;

                            _Rollingdirectionspeed = _Rollingdirection * _Speed;

                            _AnimatorManager.Falling(false);
                            _AnimatorManager.InAir(false);
                            _AnimatorManager.Speed(_Speed);
                            _AnimatorManager.JumpImpacts(0);

                        }
                       
                    } else {

                  /*      if (Vector2.Angle(collision.contacts[i].normal, (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up)) > 45) {

                            Debug.Log("WRONG, not hitting top of collider, code abit nasty buuuut time is flowing faster then sand is falling");
                            Debug.Log("Feel The Wrath Of My Edge, But It Switched Gender And Rejected You");



                            fallingspeed -= Time.deltaTime * Gravitydrag * 5;
                            _AnimatorManager.Falling(true);
                            _AnimatorManager.InAir(true);

                            Grounded = false;

                            if (Vector3.Cross(collision.contacts[i].normal, (Vector2)(Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up)).z <= 0) {
                                _Rollingdirectionspeed += Quaternion.Euler(0, 0, 90) * (Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up) * 5f;
                            } else {
                                _Rollingdirectionspeed += Quaternion.Euler(0, 0, -90) * (Quaternion.Euler(0, 0, collision.contacts[i].collider.transform.eulerAngles.z) * Vector3.up) * 5f;

                            }

                            _AnimatorManager.Speed(Mathf.Abs(_Speed));
                            body.MovePosition(transform.position + (_Rollingdirectionspeed * Time.deltaTime) + (UpVector * fallingspeed));


                        } else {

                            _Fallingdirection = Vector3.zero;
                            UpVector = collision.contacts[i].normal.normalized;
                            _Rollingdirection = (Quaternion.Euler(0, 0, -90) * collision.contacts[i].normal).normalized;
                            _Gravydirection = (Quaternion.Euler(0, 0, 180) * collision.contacts[i].normal).normalized;

                            transform.eulerAngles = collision.contacts[i].collider.transform.eulerAngles;
                            rotationspeed = 1 * (Quaternion.Angle(_Cam.rotation, transform.rotation)) * 0.05f;
                            camrotateValue = 0;
                            camrotatespeed = (Quaternion.Angle(_Cam.rotation, transform.rotation));
                            _AnimatorManager.InAir(false);
                            _AnimatorManager.Falling(false);
                            Grounded = true;
                        }*/
                    }
                    break;

                }
            
            }

        }

    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")) {
     /*       _AnimatorManager.InAir(false);
            _AnimatorManager.Falling(false);

            Grounded = true;*/
        }
        if (collision.collider.CompareTag("Wall")) {
            /*   _AnimatorManager.InAir(false);
               _AnimatorManager.Falling(false);

               Grounded = true;*/
        }

    }


  public  GameObject ground1;
    public GameObject ground2;

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.collider.CompareTag("Ground")) {
            if (ground1 != null && ground1 == collision.collider.gameObject) {
                ground1 = null;

                if (ground2 == null) {
                    _AnimatorManager.InAir(true);
                    _AnimatorManager.Falling(true);
                    Grounded = false;
                    _AnimatorManager.ChargeJump(false);

                }

            } else if (ground2 != null && ground2 == collision.collider.gameObject) {
                ground2 = null;

                if (ground1 == null) {
                    _AnimatorManager.InAir(true);
                    _AnimatorManager.Falling(true);
                    Grounded = false;
                    _AnimatorManager.ChargeJump(false);

                }

            }

        }

        if (collision.collider.CompareTag("Wall")) {
            if (onplatformground == true) {
                onplatformground = false;

                _AnimatorManager.InAir(true);
                _AnimatorManager.Falling(true);
                Grounded = false;
                _AnimatorManager.ChargeJump(false);
            }

        }

    }

}