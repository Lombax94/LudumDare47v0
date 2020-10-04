using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public int amount = 3;
    public int rotations = 2;
    public bool updateloop = true;
    public Transform[] objects;
    public float groundSize = 1f;
  
    int _amount = 3;

    Vector2 _NextPosition = Vector2.left * 0.5f;
    Vector2 _CurrentRotation = Vector2.right;
    double currentangle = 0;
    double angle = 0;

    Transform spawned;

    
    void Start() {

        if (updateloop == false) {
            updateloop = false;

            angle = -90;
            _amount = amount;
            _CurrentRotation = Vector2.down * groundSize;
            _NextPosition = Vector2.zero + (_CurrentRotation);

            spawned = Instantiate(objects[0], this.transform);
            spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
            spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

            for (int j = 0; j < rotations; j++) {
                currentangle = 180f / (_amount);

                for (int i = 0; i < _amount; i++) {
                    angle += currentangle;
                    _CurrentRotation = (Quaternion.Euler(0, 0, (float)currentangle) * _CurrentRotation).normalized * groundSize;
                    _NextPosition += _CurrentRotation;

                    spawned = Instantiate(objects[0], this.transform);
                    spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
                    spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

                }

                _amount += 3;

            }
       //     GetComponent<CompositeCollider2D>().GenerateGeometry();

        }
     //   GetComponent<CompositeCollider2D>().GenerateGeometry();

    }

    private void Update() {

        if (updateloop == true) {
            updateloop = false;

            angle = -90;
            _amount = amount;
            _CurrentRotation = Vector2.down * groundSize;
            _NextPosition = Vector2.zero + (_CurrentRotation);

            spawned = Instantiate(objects[0], this.transform);
            spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
            spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

         

            for (int j = 0; j < rotations; j++) {
                //    currentangle = 180f / (_amount + (j / 2));
                currentangle = 180f / (_amount );
                for (int i = 0; i < _amount; i++) {


                    spawned = Instantiate(objects[1], this.transform);
                    spawned.position = _NextPosition;
                    spawned.rotation = Quaternion.Euler(0, 0, (float)angle + ((float)currentangle / 2f));


                    angle += currentangle;
                    _CurrentRotation = (Quaternion.Euler(0, 0, (float)currentangle) * _CurrentRotation).normalized * groundSize;
                    _NextPosition += _CurrentRotation;

                    spawned = Instantiate(objects[0], this.transform);
                    spawned.position = _NextPosition - (_CurrentRotation * 0.5f);
                    spawned.rotation = Quaternion.Euler(0, 0, (float)angle);

                 //   spawned = Instantiate(objects[1], this.transform);
                 //   spawned.position = _NextPosition;
                 //   Debug.Log(angle + " | " + currentangle + " | " + (currentangle / 2) + " | " + (currentangle / 2f));
                 ////   spawned.rotation = Quaternion.Euler(0, 0, (float)angle);
                 //   spawned.rotation = Quaternion.Euler(0, 0, (float)angle + ((float)currentangle / 2f));

                }

                _amount += 5 ;
                //        _amount += 3 +  (j / 2);

            }
         //   GetComponent<CompositeCollider2D>().GenerateGeometry();

        }

    }

}