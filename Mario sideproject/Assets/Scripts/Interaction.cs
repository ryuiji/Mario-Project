using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

    public RaycastHit upHit;
    public RaycastHit rayHit;
    public GameObject shroomPrefab;
    public bool stopSpawn;


    void Start() {
        stopSpawn = false;
       
    }


    void Update() {
        
        spawnShroom();

    }
    void spawnShroom() {

        if (stopSpawn == false) {
            Vector3 up = transform.TransformDirection(Vector3.up);

            if (Physics.Raycast(transform.position, up, out upHit, GetComponent<MarioStats>().hitDis)) {
                if (upHit.transform.tag == "itemCube") {
                    Instantiate(shroomPrefab, GameObject.FindGameObjectWithTag("itemCube").transform.position + new Vector3(0, +1.5f, 0), transform.rotation);
                    stopSpawn = true;
                    Destroy(GameObject.Find("button_question"));
                }
            }
        }
    }

    void OnCollisionEnter (Collision col) {
         if(col.gameObject.tag == "upShroom") {
            GetComponent<MarioStats>().lifes += 1;
            Destroy(col.gameObject);
            transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z);
            GetComponent<Movement>().groundDis = 1;
        }
    }
}

