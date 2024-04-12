using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanerFromPoints : MonoBehaviour
{
    
    [SerializeField] Item box;
    [SerializeField] private List<SpawnPoint> _points;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnABox();
    }

    private void SpawnABox()
    {

        Vector3 spawnPosition = _points[Random.Range(0, _points.Count)].transform.position;

        Instantiate(box, spawnPosition, Quaternion.identity, transform);
    }
}
