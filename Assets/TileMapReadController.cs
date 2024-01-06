using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Camera _camera;
    [SerializeField] private List<TileDataSo> _tileData;
    [SerializeField] private Dictionary<TileBase, TileDataSo> _dataFromTiles;

    private void Start()
    {
        _dataFromTiles = new Dictionary<TileBase, TileDataSo>();

        foreach (TileDataSo tileData in _tileData)
        {
            foreach (TileBase tile in tileData.tiles)
            {
                _dataFromTiles.Add(tile, tileData);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTileBase(Input.mousePosition, true);
        }
    }

    public TileDataSo GetTileData(TileBase tileBase)
    {
        return _dataFromTiles[tileBase];
    }

    private TileBase GetTileBase(Vector3 position, bool mousePosition = false)
    {
        
        var gridPosition = GetGridPosition(position, mousePosition);
        TileBase tile = _tilemap.GetTile(gridPosition);
        return tile;
    }

    public Vector3Int GetGridPosition(Vector3 position, bool mousePosition)
    {
        Vector3 worldPosition;
        if (mousePosition)
        {
            worldPosition = _camera.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }
        
        Vector3Int gridPosition = _tilemap.WorldToCell(worldPosition);
        return gridPosition;
    }
}
