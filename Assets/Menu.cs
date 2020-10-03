using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int amount = 3;
    int _amount = 3;
    public int rotations = 2;
    public bool updateloop = true;

    public Transform[] objects;
    Vector2 _NextPosition = Vector2.left * 0.5f;
    Vector2 _CurrentRotation = Vector2.right;
    double currentangle = 0;
    double angle = 0;
    int counter = 0;
    // Start is called before the first frame update


    void Start() {
    /*    angle = -45;
        currentangle = 45;
        _CurrentRotation = (Quaternion.Euler(0, 0, -45) * _CurrentRotation).normalized;
        for (int i = 0; i < 3; i++) {
            angle += 45;

            _CurrentRotation = (Quaternion.Euler(0, 0, 45) * _CurrentRotation).normalized;
            _NextPosition = _NextPosition + _CurrentRotation;
            objects[counter].position = _NextPosition - (_CurrentRotation * 0.5f);
            objects[counter].rotation = Quaternion.Euler(0, 0, angle);
            counter++;

        }


        amount = 6;
        for (int j = 1; j < rotations; j++) {
            currentangle = 180 / (amount );

            for (int i = 0; i < amount; i++) {
                angle += currentangle;
                _CurrentRotation = (Quaternion.Euler(0, 0, currentangle) * _CurrentRotation).normalized;
                _NextPosition = _NextPosition + _CurrentRotation;
                objects[counter].position = _NextPosition - (_CurrentRotation * 0.5f);
                objects[counter].rotation = Quaternion.Euler(0, 0, angle);
                counter++;

            }

            amount += ( ( 2));

        }*/




    }

    Transform spawned;

    private void Update() {
        
        if(updateloop == true) {
            objects[0].gameObject.SetActive(true);
            updateloop = false;
            _NextPosition = Vector2.left;
            _CurrentRotation = Vector2.down;
            angle = -135;
            currentangle = 45;
            counter = 0;
            _amount = amount;

            _CurrentRotation = (Quaternion.Euler(0, 0, -45) * _CurrentRotation).normalized ;
            for (int i = 0; i < 5; i++) {
                angle += 45;

                _CurrentRotation = (Quaternion.Euler(0, 0, 45) * _CurrentRotation).normalized ;
                _NextPosition = _NextPosition + _CurrentRotation;
                spawned = Instantiate(objects[0], this.transform);
                spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
                spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

            }

            _amount += (2);
          //  _amount += ((2 * ++counter));
            for (int j = 1; j < rotations; j++) {
                currentangle = 180f / (_amount );


                for (int i = 0; i < _amount; i++) {
                    angle += currentangle;
                    _CurrentRotation = (Quaternion.Euler(0, 0, (float)currentangle) * _CurrentRotation).normalized ;
                    _NextPosition = _NextPosition + _CurrentRotation;
                    spawned = Instantiate(objects[0], this.transform);
                    spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
                    spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

                }

                _amount += 3;
        //        _amount += ((2 * ++counter));

            }

            objects[0].gameObject.SetActive(false);
            GetComponent<CompositeCollider2D>().GenerateGeometry();

        }


    }


}
//130, 98
//162, 130
//194, 162
//226, 194
//258, 226