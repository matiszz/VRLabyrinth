using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class InteractiveButton : MonoBehaviour {

    public int pointTime;
    
    private static GameObject menu;
    private static GameObject player;

    private const int HARD_TIME = 60;
    private const int EASY_TIME = 120;

    private bool entered = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        menu = GameObject.Find("Menu");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (entered) {
            timer += Time.deltaTime;

            if (timer > this.pointTime)
                OnSelectOption();

        } else {
            timer = 0;
        }
    }

    private void OnSelectOption() {
        PlayerWalk playerScript = player.GetComponent<PlayerWalk>();
        
        if (transform.name == "BtnEasy")
            playerScript.totalTime = EASY_TIME;
        else
            playerScript.totalTime = HARD_TIME;

        menu.SetActive(false);
        playerScript.gameStarted = true;
    }

    public void OnGazeEnter() {
        entered = true;
    }

    public void OnGazeExit() {
        entered = false;
    }
}