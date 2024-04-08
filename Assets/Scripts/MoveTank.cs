using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTank : MonoBehaviour
{
    [SerializeField] private float _moveIntensity;
    [SerializeField] private float _turnSpeed;
    
    private Rigidbody _rb;
    private Animator _animator;
    private float _inputTurn;
    private float _inputForward;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Quaternion rotation = _rb.rotation;
        // rotation.eulerAngles += Vector3.up * _inputTurn * _turnSpeed * Time.deltaTime;
        // _rb.MoveRotation(rotation);
        //
        
        //transform.Translate(transform.forward * _inputForward * _moveIntensity);
        
        _rb.MoveRotation( _rb.rotation * Quaternion.Euler(Vector3.up * _inputTurn * _turnSpeed * Time.deltaTime));
        _rb.AddForce(_rb.transform.forward * _inputForward * _moveIntensity);
        
    }
    
    public void HandleTurn(InputAction.CallbackContext context)
    {
        _inputTurn = context.ReadValue<float>();
    }

    public void HandleForward(InputAction.CallbackContext context)
    {
        _inputForward = context.ReadValue<float>();
    }
}
