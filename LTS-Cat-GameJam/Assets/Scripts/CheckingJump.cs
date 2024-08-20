using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingJump : MonoBehaviour
{
    public bool characterCanJump;
    public float jumpReset;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Character on ground");
            characterCanJump = true; 
        }

    }
}
