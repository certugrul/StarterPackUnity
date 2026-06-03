using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
   [ SerializeField] private Transform _Orientationtransform;

    [Header("Movement Settings")]
    [SerializeField] private float _PlayerSpeed = 10f;


    [Header("Jump Settings")]
    [SerializeField] private KeyCode _JumpKey;
    
    [SerializeField] private float _JumpForce = 5f;
    [SerializeField] private float _JumpCooldown = 1f;
    
    [SerializeField] private bool _CanJump= true;
    
    [Header("Ground Check Settings")]
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask groundLayer;


    




    private Rigidbody rb;

    private float horizontalInput, verticalInput;

    private Vector3 movementDirection;
   

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }
    private void Update()
    {
        SetInputs();

    }
    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetInputs()
    {
        horizontalInput = 
        Keyboard.current.aKey.isPressed ? -1 
        : Keyboard.current.dKey.isPressed ? 1 : 0;

        verticalInput = 
        Keyboard.current.wKey.isPressed ? 1 
        : Keyboard.current.sKey.isPressed ? -1 : 0;


        if(Keyboard.current.spaceKey.wasPressedThisFrame && _CanJump && IsGrounded())
        {
             _CanJump = false;
            
            PlayerJump();
             Invoke(nameof(ResetJump), _JumpCooldown);
        }
        
        
}

    private void SetPlayerMovement() 
    {
        movementDirection =
         _Orientationtransform.forward * verticalInput + 
        _Orientationtransform.right * horizontalInput;

        rb.AddForce(movementDirection.normalized*_PlayerSpeed, ForceMode.Force);


    }

    private void PlayerJump()
    {
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

}
