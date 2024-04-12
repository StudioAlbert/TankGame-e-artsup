using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTurret : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _canonTurnSpeed;
    [SerializeField] private Transform _canon;
    
    private float _inputTurn;
    private float _inputUpDown;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, _inputTurn * _turnSpeed * Time.deltaTime);

        _canon.Rotate(Vector3.right, _inputUpDown * _canonTurnSpeed * Time.deltaTime);
        
    }
    
    public void HandleTurn(InputAction.CallbackContext context)
    {
        _inputTurn = context.ReadValue<float>();
    }
    public void HandleTurnUpDown(InputAction.CallbackContext context)
    {
        _inputUpDown = context.ReadValue<float>();
    }
}
