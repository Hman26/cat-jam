using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public PlayerController pc;
    public Transform square;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void FixedUpdate()
    {
        this.transform.position = square.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speed")
        {
            Debug.Log("Speed increased");
            pc.speed += 5;
            Debug.Log(pc.speed); 
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Lap completed");
            gameManager.currentLap++; 

        }
    }
}
