using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    private Collider _zone;
    
    // Start is called before the first frame update
    void Start()
    {
        _zone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Random.Range(_zone.bounds.min.x,  _zone.bounds.max.x);
        Random.Range(_zone.bounds.min.z,  _zone.bounds.max.z);
    }
}
