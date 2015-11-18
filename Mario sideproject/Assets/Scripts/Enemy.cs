using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int moveSpeed;
    public int life;
    public RaycastHit rightHit;
    public RaycastHit leftHit;
    public float hitDis;


    void Start() {
        life = 1;
    }


    void Update() {
        Move();
        lifes();
    }


    void Move() {
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, out rightHit, hitDis)) {
            if (rightHit.transform.tag == "Pipe") {
                moveSpeed = -5;
            }
        }
            Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, out leftHit, hitDis)) {
            if (leftHit.transform.tag == "Pipe") {
                moveSpeed = 5;
            }
        }
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

        void lifes() {
            if (life == 0) {
                Destroy(gameObject);
            }
        }
    }
