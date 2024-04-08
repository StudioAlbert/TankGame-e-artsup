using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _nbBoxes = 9;
    [SerializeField] [Range(1, 10)] private float _radius = 5;

    [SerializeField] private List<Item> _boxes;
    
    [SerializeField] private List<Collider> _spawnAreas;

    private List<Item> _items = new List<Item>();
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (_items.Count <= 0)
        {
            Debug.Log("End Game !!!!!!!!!!!!!!!!!!!!!");
            
            Spawn();
            
        }
        
    }

    public void Spawn()
    {

        for (int i = 0; i < _nbBoxes; i++)
        {
            // Spawn inside a square (size of the square = radius x radius)
            // Vector3 position = _radius * new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            // Spawn inside a circle (size of the circle = radius)
            // Vector3 position = _radius * Random.insideUnitCircle;

            Collider spawnArea = _spawnAreas[Random.Range(0, _spawnAreas.Count)];

            Vector3 position;
            Vector3 closestPoint;
            do
            {
                position = new Vector3(
                    Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                    0,
                    Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
                );

                closestPoint = spawnArea.ClosestPoint(position);

            } while (Vector3.Distance(closestPoint, position) > 0f);
            
            Item instance = Instantiate<Item>(_boxes[Random.Range(0, _boxes.Count)], position, Quaternion.identity, this.transform);
            
            instance.IsTouched += ItemTouched;
            _items.Add(instance);

        }
        
    }

    public void ItemTouched(Item item)
    {
        if (_items.Contains(item))
        {
            Debug.Log("Item touched !!!!!!!!!!");
            _items.Remove(item);
        }
    }
    
}
