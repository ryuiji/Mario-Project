using UnityEngine;
using System.Collections;

public class MarioStats : MonoBehaviour {

    public int lifes;
    public RaycastHit leftHit;
    public RaycastHit rightHit;
    public float hitDis;



    void Start() {
        lifes = 1;
    }

    void Update() {
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 right = transform.TransformDirection(Vector3.right);

        if (Physics.Raycast(transform.position, left, out leftHit, hitDis)) {
            if (leftHit.transform.tag == "Enemy") {
                lifes -= 1;
            }
        }
        if (Physics.Raycast(transform.position, right, out rightHit, hitDis)) {
            if (rightHit.transform.tag == "Enemy") {
                lifes -= 1;
            }
        }
        if (lifes == 0) {
            Destroy(gameObject);
        }
    }
}
