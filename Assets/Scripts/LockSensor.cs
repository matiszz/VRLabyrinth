using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSensor : MonoBehaviour {
    private static GameObject door;
    private static GameObject key;
    private KeyController keyScript;

    // Start is called before the first frame update
    void Start() {
        door = GameObject.Find("Door");
        key = GameObject.Find("Key");
        keyScript = key.GetComponent<KeyController>();
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Key") && keyScript.yRotation % 360 == 315) {
            DoorController doorScript = door.GetComponent<DoorController>();
            doorScript.isOpening = true;
            key.SetActive(false);
        }
    }
}
