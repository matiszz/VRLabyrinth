﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWalk : MonoBehaviour {

    public int playerSpeed;
    public int totalCoins;
    public int totalTime;
    public bool musicEnabled;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timeText;
    public GameObject winText;
    public GameObject lostCoinsText;
    public GameObject lostTimeText;
    public AudioSource backgroundMusic;

    public bool gameStarted = false;

    public int countCoins;
    public bool hasKey;

    private float timeLeft;
    private bool firstTime = true;


    // Start is called before the first frame update
    void Start() {
        countCoins = 0;

        winText.SetActive(false);
        lostCoinsText.SetActive(false);
        lostTimeText.SetActive(false);
        
        SetCountText();
        UpdateTimeText();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1")) {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

        // Update the timeLeft with the public TotalTime once it's set
        if (gameStarted && firstTime) OnStartGame();

        UpdateTimeText();
        SetCountText();
    }

    void OnStartGame() {
        firstTime = false;
        timeLeft = totalTime;
        
        if (musicEnabled) {
            backgroundMusic = GetComponent<AudioSource>();
            backgroundMusic.Play(0);
        } 
    }

    void UpdateTimeText() {
        if (gameStarted) {
            timeLeft -= Time.deltaTime;
            
            if (timeLeft > 0) {
                timeText.text = "Time left: " + Mathf.Round(timeLeft).ToString();
            } else {
                lostTimeText.SetActive(true);
                playerSpeed = 0;
            }
        }
    }

    void SetCountText() {
        coinText.text = "Coins: " + countCoins.ToString() + "/" + totalCoins.ToString();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Meta")) {
            OnArriveFinish();
        }
    }

    private void OnArriveFinish() {
        if (timeLeft > 0) {
            if (countCoins == totalCoins) {
                winText.SetActive(true);
            } else {
                lostCoinsText.SetActive(true);
            }
            
            playerSpeed = 0;
            gameStarted = false;
        }
    }
}
