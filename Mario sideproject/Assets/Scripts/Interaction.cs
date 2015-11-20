using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    public RaycastHit upHit;
    public GameObject shroomPrefab;
    void Start() {

    }


    void Update() {
        Vector3 up = transform.TransformDirection(Vector3.up);
        if (Physics.Raycast(transform.position, up, out upHit, GetComponent<MarioStats>().hitDis)) {
            if (upHit.transform.tag == "itemCube") {
                Instantiate(shroomPrefab, GameObject.FindGameObjectWithTag("itemCube").transform.position + new Vector3(0,+1.5f,0), transform.rotation);
            }
        }
    }
}
