using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 20f;
    [SerializeField] private float _timeLimit = 2f;

    private float _lifeTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * _projectileSpeed * Time.deltaTime;
        transform.position = transform.position + movement;

        _lifeTime += Time.deltaTime;
        //_lifeTime = _lifeTime + Time.deltaTime;
        
        if (_lifeTime > _timeLimit)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Desctructible"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

}
