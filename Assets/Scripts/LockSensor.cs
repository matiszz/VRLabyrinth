using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSensor : MonoBehaviour {
    private static GameObject door;
    private static GameObject key;

    // Start is called before the first frame update
    void Start() {
        door = GameObject.Find("Door");
        key = GameObject.Find("Key");
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Key")) {
            DoorController doorScript = door.GetComponent<DoorController>();
            doorScript.isOpening = true;
            key.SetActive(false);
        }
    }
}
