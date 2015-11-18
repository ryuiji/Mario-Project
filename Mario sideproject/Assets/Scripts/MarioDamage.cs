using UnityEngine;
using System.Collections;

public class MarioDamage : MonoBehaviour {

    public RaycastHit downHit;
    public float hitDis;
    public float boost;

    void Start() {

    }


    void Update() {
        Vector3 down = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, down, out downHit, hitDis)){
            if (downHit.transform.tag == "Enemy") {
                GameObject.Find("Enemy").GetComponent<Enemy>().life -= 1;
                GetComponent<Rigidbody>().AddForce(transform.up * boost);
            }
        }
    }
}
