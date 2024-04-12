using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int _nbBoxes = 9;
    [SerializeField] [Range(1, 10)] private float _radius = 5;
    [SerializeField] private List<Item> _prefabBoxes;
    [SerializeField] private List<Collider> _spawnAreas;
    [SerializeField] private HUD _hud;
    
    
    private List<Item> _items = new List<Item>();
    public string RemaingItemsCount; 
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        _hud.SetEnnemiesLabel("00 / 00");
        _hud.HideEndGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (_items.Count <= 0)
        {
            _hud.ShowEndGame();
            Spawn();
        }
        
        _hud.SetEnnemiesLabel(_items.Count + " / " + _nbBoxes);
        
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
            
            Item instance = Instantiate<Item>(_prefabBoxes[Random.Range(0, _prefabBoxes.Count)], position, Quaternion.identity, this.transform);
            
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
