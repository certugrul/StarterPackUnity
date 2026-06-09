using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
   public event Action OnPlayerJump;
    [Header("References")]

   [ SerializeField] private Transform _Orientationtransform;
    [Header("Movement Settings")]
    [SerializeField] private KeyCode _PlayerSpeedKey;
    [SerializeField] private float _PlayerSpeed;





    [Header("Sliding Settings")]

    [SerializeField] private KeyCode _SlideKey;
    [SerializeField] private float _SlideMultiplier;
    [SerializeField] private float _SlideDrag;
    


    [Header("Jump Settings")]

    [SerializeField] private KeyCode _JumpKey;
    [SerializeField] private float _JumpForce ;
    [SerializeField] private float _JumpCooldown ;
    [SerializeField] private bool _CanJump;
    [SerializeField] private float airMultiplier;
    [SerializeField] private float _AirDrag;
    




    [Header("Ground Check Settings")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _GroundDrag;


    

    private StateController _stateController;
    private bool _isSliding;
    private Rigidbody rb;

    private float horizontalInput, verticalInput;

    private Vector3 movementDirection;
   

    void Awake()
    {
        _stateController = GetComponent<StateController>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    private void Update()
    {
        SetInputs();
        SetStates();
        SetPlayerDrag();
        LimitPlayerSpeed();

    }
    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        {horizontalInput = 
        Keyboard.current.aKey.isPressed ? -1 
        : Keyboard.current.dKey.isPressed ? 1 : 0;

        verticalInput = 
        Keyboard.current.wKey.isPressed ? 1 
        : Keyboard.current.sKey.isPressed ? -1 : 0;}

       
       if(Keyboard.current.spaceKey.wasPressedThisFrame && _CanJump && IsGrounded())
        {
             _CanJump = false;
           
            PlayerJump();
             Invoke(nameof(ResetJump), _JumpCooldown);
        }
        else if(Keyboard.current.leftShiftKey.isPressed)
        {
        _isSliding = true;
        }
        else 
        {
        _isSliding = false;
        }
        
        
        
        
        
       
}


    private void SetStates()
    {
       var movementDirection = GetMovementDirection();
       var isGrounded = IsGrounded();
       var isSliding = IsSliding();
       var currentState = _stateController.GetCurrentState();

       var newState = currentState switch
       {
           _ when movementDirection == Vector3.zero && isGrounded && !isSliding => PlayerState.Idle,
           _ when movementDirection != Vector3.zero && isGrounded && !isSliding => PlayerState.Move,
           _ when movementDirection != Vector3.zero && isGrounded && isSliding => PlayerState.Slide,
           _ when movementDirection == Vector3.zero && isGrounded && isSliding => PlayerState.SlideIdle,
           _ when !_CanJump&& !isGrounded => PlayerState.Jump,
           _ => currentState

       };
       if(newState != currentState)
       {
        _stateController.ChangeState(newState);
       }
    //    Debug.Log(newState);
    }

    private void SetPlayerMovement() 
    {
        movementDirection =
         _Orientationtransform.forward * verticalInput + 
        _Orientationtransform.right * horizontalInput;

            float forceMultiplier = _stateController.GetCurrentState() switch
            {
              PlayerState.Move => 1f,
                PlayerState.Slide => _SlideMultiplier,
                PlayerState.Jump=> airMultiplier,
                _ => 1f
            };
           
                rb.AddForce(movementDirection.normalized*_PlayerSpeed*forceMultiplier, ForceMode.Force);
           


    }
    private void SetPlayerDrag()
    {

        rb.linearDamping = _stateController.GetCurrentState() switch
        {
            PlayerState.Move => _GroundDrag,
            PlayerState.Slide => _SlideDrag,
            PlayerState.Jump => _AirDrag,
            _ => rb.linearDamping
        };
       if(_isSliding)

        {
            rb.linearDamping = _SlideDrag;
        }
        else
        {
            rb.linearDamping = _GroundDrag;
        }
    }
    private void LimitPlayerSpeed()
    {
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.z);
        if(flatVelocity.magnitude > _PlayerSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * _PlayerSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void PlayerJump()
    {
        
        OnPlayerJump?.Invoke();
        rb.linearVelocity= new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * _JumpForce, ForceMode.Impulse);


    }

    private void ResetJump()
    {
        _CanJump = true;
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f + 0.2f,groundLayer);
    }
    
    private Vector3 GetMovementDirection()
    {
        return movementDirection.normalized;
    }

    private bool IsSliding()
    {
        return _isSliding;
    }

}
