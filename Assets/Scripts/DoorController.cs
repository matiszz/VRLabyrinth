using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public float openSpeed = 2;
    public bool isOpening = false;
    private Vector3 target;

    // Start is called before the first frame update
    void Start() {
        target = transform.position + new Vector3(-6, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        if (isOpening) {
            float step = openSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}
