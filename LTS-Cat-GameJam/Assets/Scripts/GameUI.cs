using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameUI : MonoBehaviour
{
  

    public void StartGame() { SceneManager.LoadScene("Intro");  } 
    public void QuitGame() { Application.Quit(); }
}
