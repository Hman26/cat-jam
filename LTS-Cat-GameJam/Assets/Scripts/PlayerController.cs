using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    // VARIABLES
    private Vector2 _input; 
    private CharacterController _characterController;
    private float _gravity = 9.81f;
    private float _velocity;
    private Rigidbody2D rb;
    public CheckingJump jumpScript;
    public float speed; 

    [SerializeField] private float gravityMultiplier = 3.0f; 
    [SerializeField] private float jumpPower;

    //Ground Check
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [Header("Wwise Events")]
    public AK.Wwise.Event footstep;
    //public AK.Wwise.Event land;
    public bool isPlayingFootsteps = false;
    public float lastFootstepTime = 0;


    // CODE FOR MOVEMENT
    private void Awake()
    {
        _characterController= GetComponent<CharacterController>();
        rb = GetComponentInChildren<Rigidbody2D>();
        jumpScript = GetComponentInChildren<CheckingJump>();

        lastFootstepTime = Time.time;
    }

    private void Update()
    {
        ApplyMovement();
        
    }

    private void ApplyMovement()
    {
        _characterController.Move(_input * speed * Time.deltaTime);
        if (isPlayingFootsteps == false)
                {
                    footstep.Post(gameObject);
                    lastFootstepTime = Time.time;
                    isPlayingFootsteps = true;
                }
                else
                {
                    if (_input.x != 0 && jumpScript.characterCanJump == true)
                    {
                        if ((Time.time - lastFootstepTime) > (/*212 * Time.deltaTime*/ .3))
                        {
                            isPlayingFootsteps = false;

                        }
                    }
                }
    }

    //INPUT ACTIONS
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        Debug.Log(_input);  
    }

    public void Jump(InputAction.CallbackContext context)
    {
       if(context.performed && jumpScript.characterCanJump == true)
       {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpScript.characterCanJump = false;

            if (isPlayingFootsteps == true)
            {
                footstep.Stop(gameObject);
            }
        }
    }

    // ---- GAME RULES ----
  

    // ----- NOTES -----
    /*Character needs to go left and right, up and down, and have speed variable that increases the more laps the cat goes around the house*/
}
