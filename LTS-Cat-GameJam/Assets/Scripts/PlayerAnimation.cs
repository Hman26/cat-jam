using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation Variables")]
    public Animator playerAnimator;

    [Header("Player Transform")]
    public GameObject player;
    private Vector3 leftScale = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 rightScale = new Vector3(-1.0f, 1.0f, 1.0f);

    [Header("Script Variables")]
    public CheckingJump jumpScript;

    void Awake()
    {
        //setting variables to false so players start with idle animation
        playerAnimator.SetBool("Walking", false);
        playerAnimator.SetBool("InAir", false);
    }


    void Update()
    {
        //checking first to see if the player is in the air and jumping
        if (jumpScript.characterCanJump == true)
        {
            playerAnimator.SetBool("InAir", false);
        }
            //if player is not jumping and is trying to run to right
            if (jumpScript.characterCanJump == true && Input.GetKeyDown(KeyCode.LeftArrow) || jumpScript.characterCanJump == true && Input.GetKey(KeyCode.LeftArrow) || jumpScript.characterCanJump == true && Input.GetKeyDown(KeyCode.D) || jumpScript.characterCanJump == true && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("Walking", true);
            player.transform.localScale = leftScale;
        }
        //if player has stopped running to right
        if (jumpScript.characterCanJump == true && Input.GetKeyUp(KeyCode.LeftArrow) || jumpScript.characterCanJump == true && Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("Walking", false);
            player.transform.localScale = leftScale;
        }
        //iif player is not jumping and is trying to run to left
        if (jumpScript.characterCanJump == true && Input.GetKeyDown(KeyCode.RightArrow) || jumpScript.characterCanJump == true && Input.GetKey(KeyCode.RightArrow)|| jumpScript.characterCanJump == true && Input.GetKeyDown(KeyCode.A) || jumpScript.characterCanJump == true && Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("Walking", true);
            player.transform.localScale = rightScale;
        }
        //if player has stopped running to left
        if (jumpScript.characterCanJump == true && Input.GetKeyUp(KeyCode.RightArrow) || jumpScript.characterCanJump == true && Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("Walking", false);
            player.transform.localScale = rightScale;
        }
        //if the player has left the ground the jump animation plays
        if(jumpScript.characterCanJump == false)
        {
            playerAnimator.SetBool("InAir", true);
            playerAnimator.SetBool("Walking", false);
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                player.transform.localScale = leftScale;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                player.transform.localScale = rightScale;
            }
        }
    }
}
