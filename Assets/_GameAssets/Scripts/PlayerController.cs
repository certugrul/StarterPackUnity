using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
   [ SerializeField] private Transform _Orientationtransform;

    [Header("Movement Settings")]
    [SerializeField] private float _PlayerSpeed = 10f;

    private Rigidbody rb;

    private float horizontalInput, verticalInput;

    private Vector3 movementDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

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
        
        
}

    private void SetPlayerMovement() 
    {
        movementDirection =
         _Orientationtransform.forward * verticalInput + 
        _Orientationtransform.right * horizontalInput;

        rb.AddForce(movementDirection*_PlayerSpeed, ForceMode.Force);


    }
}
