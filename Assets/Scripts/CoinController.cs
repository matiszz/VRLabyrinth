using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    public float pointTime;

    private static GameObject player;

    private bool entered;
    private float timer = 0;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        OnRotate();

        if (entered) {
            timer += Time.deltaTime;

            if (timer > this.pointTime)
                OnCollectCoin();
        } else {
            timer = 0;
        }
    }

    private void OnRotate() {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }

    private void OnCollectCoin() {
        PlayerWalk playerScript = player.GetComponent<PlayerWalk>();
        
        playerScript.countCoins++;

        gameObject.SetActive(false);
    }

    public void OnGazeEnter() {
        entered = true;
    }

    public void OnGazeExit() {
        entered = false;
    }
}
