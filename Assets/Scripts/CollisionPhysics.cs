using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionPhysics : MonoBehaviour
{
    private Vector2 _move;
    private bool _jump;
    
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private ForceMode _forceMode;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_move.x, 0, _move.y) * (_speed * Time.deltaTime);

        if (_jump)
        {
            Debug.Log("rocket science, baby !");
            _rb.AddForce(Vector3.up * _jumpForce, _forceMode);
        }
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
        
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        _jump = context.ReadValueAsButton();
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("Collision enter");
    // }
    //
    // private void OnCollisionExit(Collision other)
    // {
    //     Debug.Log("Collision exit");
    // }
    //
    // private void OnCollisionStay(Collision other)
    // {
    //     Debug.Log("Collision stay");
    // }


}
