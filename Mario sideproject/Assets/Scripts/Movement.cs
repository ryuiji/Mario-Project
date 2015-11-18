using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 jumpSpeed;
    public bool mayJump;
    public float groundDis;
    public int jumpTimes;
    public int moveSpeed;
    public int jumpAdjust;
    public GameObject mainCamera;
    public float x;
    public bool wayFacing;
    public int faceLeft;


    void Start() {
        rb = GetComponent<Rigidbody>();
        mayJump = true;
        wayFacing = true;
        faceLeft = -1;
        jumpSpeed.y = 7;
    }


    void Update() {

        x = transform.position.x;
        mainCamera.transform.position = new Vector3 (x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        movement();
        flip();

        if (Input.GetButtonDown("Jump")) {
            if (Physics.Raycast(transform.position, Vector3.down, groundDis))
                jumpTimes = 0;
                jump();
        }
        
    }
    void movement() {
        if (Input.GetButton("A")) {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            wayFacing = false;
        }

        if (Input.GetButton("D")) {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            wayFacing = true;
        }
    }
    void flip() {
        if (wayFacing == false) {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        if (wayFacing == true) {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    void jump() {
        if (jumpTimes < 1) {
            rb.velocity += jumpSpeed;
            jumpAdjust++;
            jumpTimes = 1;
        }
        if (jumpAdjust == 1) {
            jumpSpeed.y = 8f;
        }
        if (jumpAdjust == 2) {
            jumpSpeed.y = 9f;
        }
        if (jumpAdjust >= 3) {
            jumpAdjust = 0;
            jumpSpeed.y = 7f;
        }
    }
}   


