using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameUI : MonoBehaviour
{
  

    public void StartGame() { SceneManager.LoadScene("LevelOne");  } 
    public void QuitGame() { Application.Quit(); }
}
