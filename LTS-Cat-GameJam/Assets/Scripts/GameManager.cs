using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] public float _gameTimer;
    [SerializeField] public float Max_gameTimer;
    [SerializeField] private int _gameLaps;
    public int currentLap;

    // USER INTERFACE
    public TextMeshProUGUI timerTxt; 
    public TextMeshProUGUI lapsTxt;
    public GameObject _goldStarOne;
    public GameObject _goldStarTwo;
    public GameObject _goldStarThree;
    public GameObject _greyStarOne;
    public GameObject _greyStarTwo;
    public GameObject _greyStarThree;
    public UnityEngine.UI.Image fillBar;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("StarGoals")]
    public float oneStarMin;
    public float oneStarMax;
    public float twoStarMin;
    public float twoStarMax;


    //WWISE
    public AK.Wwise.Event playBGM;


    private void Start()
    {
        Max_gameTimer = _gameTimer;
        playBGM.Stop(gameObject);

        _goldStarOne.SetActive(true); 
        _goldStarTwo.SetActive(true); 
        _goldStarThree.SetActive(true); 

        playBGM.Post(gameObject);

        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void Update()
    {
        //---- Game Timer -----
        _gameTimer -= Time.deltaTime;
        timerTxt.text = _gameTimer.ToString("0.00");

        fillBar.fillAmount = _gameTimer / Max_gameTimer; 

        if (_gameTimer <= 0)
        {
            Debug.Log("Time is up!");  
            _gameTimer = 0; 
        }
        if (_gameTimer <= twoStarMax)
        {
            _goldStarOne.SetActive(false);
        }
        if (_gameTimer <= oneStarMax)
        {
            _goldStarTwo.SetActive(false);
            _goldStarOne.SetActive(false);
        }
        if (_gameTimer <= oneStarMin)
        {
            _goldStarTwo.SetActive(false);
            _goldStarOne.SetActive(false);
            _goldStarThree.SetActive(false);
        }

        lapsTxt.text = currentLap.ToString() + "/" + _gameLaps.ToString();
        //----- Lap Tracker -----
        if (currentLap >= _gameLaps)
        {
            Debug.Log("Round is done :)");
            float roundFinishTime = _gameTimer;
            // Then, check what time they got and see what star they got
            if (roundFinishTime >= twoStarMin && roundFinishTime <= twoStarMax)
            {
                Debug.Log("You get 2 stars");
                _goldStarOne.SetActive(false);
            }
            if (roundFinishTime >= oneStarMin && roundFinishTime <= oneStarMax)
            {
                Debug.Log("You got 1 star");
                _goldStarTwo.SetActive(false);
                _goldStarOne.SetActive(false);
            }
            if (roundFinishTime < oneStarMin)
            {
                Debug.Log("You got no stars :(");
                _goldStarThree.SetActive(false);
                _goldStarTwo.SetActive(false);
                _goldStarOne.SetActive(false);
                losePanel.SetActive(true);
                PauseGame();
            }
            else
            {
                Debug.Log("You got 3 stars!");
            }
        }
        if (currentLap >= 3 && _gameTimer >= 0)
        {
            winPanel.SetActive(true);
            _gameTimer = 0;
            PauseGame();
        }
        if (currentLap < 3 && _gameTimer <= 0)
        {
            _goldStarThree.SetActive(false);
            _goldStarTwo.SetActive(false);
            _goldStarOne.SetActive(false);
            losePanel.SetActive(true);
            PauseGame();
        }
    }
    public void PauseGame()
    {
        //pauses the game by setting the time to zero and returning
        Time.timeScale = 0;
        return;
    }
    public void UnpauseGame()
    {
        //unpauses the game by setting the time to 1
        Time.timeScale = 1;
        return;
    }
}
