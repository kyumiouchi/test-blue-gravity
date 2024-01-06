using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Crops
{
    
}
public class CropsManager : MonoBehaviour
{
    [SerializeField] private TileBase _plowed;
    [SerializeField] private TileBase _seeded;
    [SerializeField] private Tilemap _targetTilemap;

    private Dictionary<Vector2Int, Crops> _crops;
    
    private void Start()
    {
        _crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool Check(Vector3Int position)
    {
        return _crops.ContainsKey((Vector2Int)position);
    }
    
    public void Plow(Vector3Int position)
    {
        if (_crops.ContainsKey((Vector2Int)position))
            return;

        CreatePlowedTile(position);
    }
    
    public void Seed(Vector3Int position)
    {
        _targetTilemap.SetTile(position, _seeded);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        Crops crops = new Crops();
        _crops.Add((Vector2Int)position, crops);
        _targetTilemap.SetTile(position, _plowed);
        
    }
}
