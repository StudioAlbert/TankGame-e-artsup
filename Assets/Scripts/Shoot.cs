using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    private Animator _animator;
    
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _parent;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleShoot(InputAction.CallbackContext context)
    {
        bool shootInput = context.ReadValueAsButton();
        Debug.Log("Is shooting ? " + shootInput);
        
        _animator.SetBool("IsShooting", shootInput);

        if (shootInput)
        {
            Instantiate(_projectile, _parent.transform.position, _parent.transform.rotation);
        }
        
    }

}
