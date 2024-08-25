using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReset : MonoBehaviour
{

    public GameManager gameManager;
    public float timerAmount;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager._gameTimer = timerAmount;
        gameManager.UnpauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
