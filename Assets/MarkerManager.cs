using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] private Tilemap _targetTilemap;
    [SerializeField] private TileBase _tile;
    public Vector3Int markedCellPosition;
    private Vector3Int oldCellPosition;
    
    private void Update()
    {
        _targetTilemap.SetTile(oldCellPosition, null);
        _targetTilemap.SetTile(markedCellPosition, _tile);
        oldCellPosition = markedCellPosition;
    }
}
