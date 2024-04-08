using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public event Action<Item> IsTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsTouched?.Invoke(this);
            Destroy(gameObject);
        }
        
    }

}
