using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private float _gameTimer;
    [SerializeField] private int _gameLaps;
    public int currentLap;

    // USER INTERFACE
    public TextMeshProUGUI timerTxt; 
    public TextMeshProUGUI lapsTxt;
    public GameObject _goldStarOne;
    public GameObject _goldStarTwo;
    public GameObject _goldStarThree;


    private void Start()
    {
        _goldStarOne.SetActive(true); 
        _goldStarTwo.SetActive(true); 
        _goldStarThree.SetActive(true); 
    }

    private void Update()
    {
        //---- Game Timer -----
        _gameTimer -= Time.deltaTime;
        timerTxt.text = _gameTimer.ToString("0.00"); 
        if (_gameTimer <= 0)
        {
            Debug.Log("Time is up!");  
            _gameTimer = 0; 
        }

        //----- Lap Tracker -----
        if (currentLap >= _gameLaps)
        {
            Debug.Log("Round is done :)");
            float roundFinishTime = _gameTimer; 
            // Then, check what time they got and see what star they got
            if (roundFinishTime >= 0 && roundFinishTime <= 10)
            {
                Debug.Log("You got 1 star");
                _goldStarTwo.SetActive(false);
                _goldStarOne.SetActive(false);
            }
            else if (roundFinishTime <= 11 && roundFinishTime <= 20)
            {
                Debug.Log("You get 2 stars");
                _goldStarThree.SetActive(false); 
            }
            else
            {
                Debug.Log("You got 3 stars!");
            }
        }
        lapsTxt.text = currentLap.ToString() + "/" + _gameLaps.ToString();
    }
}
