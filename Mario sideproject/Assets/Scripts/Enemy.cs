using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int moveSpeed;
    public bool faceWay;


    void Start() {
        faceWay = true;
    }


    void Update() {
        Move();
        flip();
    }


    void Move() {
        if (transform.position.x <= -2.5) {
            moveSpeed = 5;
            faceWay = true;

        }
        if (transform.position.x >= 2.5) {
            moveSpeed = -5;
            faceWay = false;
        }
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }


    void flip() {
        if(faceWay == true){
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        } else {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
}