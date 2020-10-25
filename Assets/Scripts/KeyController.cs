using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
    public float pointTime;

    public AudioSource keySound;
    private static GameObject player;
    private static GameObject camera;
    private PlayerWalk playerScript;

    private bool entered;
    private float timer = 0;

    void Start() {
        player = GameObject.Find("Player");
        camera = GameObject.Find("GvrReticlePointer");
        playerScript = player.GetComponent<PlayerWalk>();
    }

    // Update is called once per frame
    void Update() {
        OnAttachKeyToPlayer();

        if (entered) {
            timer += Time.deltaTime;

            if (timer > this.pointTime)
                OnCollectKey();
        } else {
            timer = 0;
        }
    }
    
    private void OnAttachKeyToPlayer() {
        if (playerScript.hasKey) {
            transform.position = camera.transform.position + camera.transform.rotation * new Vector3(1, 0, 3);
            transform.rotation = camera.transform.rotation * Quaternion.Euler(180, 90, -90);
        }
    }

    private void OnCollectKey() {
        keySound = GetComponent<AudioSource>();
        keySound.Play(0);

        playerScript.hasKey = true;
    }

    public void OnGazeEnter() {
        entered = true;
    }

    public void OnGazeExit() {
        entered = false;
    }
}