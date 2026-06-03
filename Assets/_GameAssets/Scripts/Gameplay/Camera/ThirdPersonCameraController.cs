using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform _PlayerTransform;
    [SerializeField] private Transform _OrientationTransform;
    [SerializeField] private Transform _PlayerVisualTransform;



    [Header("Settings")]

    [SerializeField] private float _rotationSpeed;


    private void Update()
    {
        Vector3 viewDirection = _PlayerVisualTransform.position - new Vector3(transform.position.x, _PlayerTransform.position.y, transform.position.z);

        _OrientationTransform.forward = viewDirection.normalized;
    
        float horizontalInput, verticalInput;
       
        {horizontalInput = 
        Keyboard.current.aKey.isPressed ? -1 
        : Keyboard.current.dKey.isPressed ? 1 : 0;

        verticalInput = 
        Keyboard.current.wKey.isPressed ? 1 
        : Keyboard.current.sKey.isPressed ? -1 : 0;}


      
      
        Vector3 inputDirection = 
        _OrientationTransform.forward * verticalInput + _OrientationTransform.right * horizontalInput;


        if(inputDirection != Vector3.zero)
        {
             _PlayerVisualTransform.forward = 

        Vector3.Slerp(_PlayerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);

        }
       




    }
    





}

    
