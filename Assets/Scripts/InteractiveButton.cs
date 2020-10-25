﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour {

    public int pointTime;
    // public TextMeshProUGUI soundBtnText;
    
    private static GameObject menu;
    private static GameObject main;
    private static GameObject settings;
    private static GameObject player;

    private const int HARD_TIME = 100;
    private const int EASY_TIME = 140;

    private bool entered = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        menu = GameObject.Find("Menu");
        settings = GameObject.Find("SettingsCanvas");
        main = GameObject.Find("MenuCanvas");
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
        Debug.Log("HOLA " + transform.name);
        
        if (transform.name == "BtnEasy") {
            playerScript.totalTime = EASY_TIME;
            menu.SetActive(false);
            playerScript.gameStarted = true;

        } else if (transform.name == "BtnHard") {
            playerScript.totalTime = HARD_TIME;
            menu.SetActive(false);
            playerScript.gameStarted = true;

        } else if (transform.name == "BtnSettings") {
            DisplayObject(main, false);
            DisplayObject(settings, true);

        } else if (transform.name == "BtnBack") {
            Debug.Log("HOLaaaaaA");
            DisplayObject(main, true);
            DisplayObject(settings, false);

        } else if (transform.name == "BtnMusic") {
            if (playerScript.musicEnabled)
                soundBtnText.text = "Music OFF";
            else
                soundBtnText.text = "Music ON";
                
            playerScript.musicEnabled = !playerScript.musicEnabled;
        //    gameObject.GetComponentInChildren(Text).text = "testing";
        }

    }

    public void OnGazeEnter() {
        entered = true;
    }

    public void OnGazeExit() {
        entered = false;
    }

    private void DisplayObject(GameObject gameObject, bool show) {
        int change = 10;
        if (!show) change = -10;

        gameObject.transform.position = (gameObject.transform.position + new Vector3(0, change, 0));
    }
}