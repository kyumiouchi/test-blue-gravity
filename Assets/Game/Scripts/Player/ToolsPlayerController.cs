using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsPlayerController : MonoBehaviour
{
    [SerializeField] private HighlightController _highlightController;
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] private float _sizeRadiuInteractableArea = 1.2f;
    [SerializeField] private MarkerManager _markerManager;
    [SerializeField] private TileMapReadController _tileMapReadController;
    [SerializeField] private float _maxDistance = 1.5f;
    [SerializeField] private CropsManager _cropsManager;
    [SerializeField] private TileDataSo _plowableTiles;
    
    private PlayerController _playerController;
    private Rigidbody2D _playerRigidbody2D;
    private bool _isHighlight;
    private Vector3Int _selectedTilePosition;
    private bool _selectable;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (InteractionWithObject(Input.GetMouseButtonDown(0)))
            return;
        if (Input.GetMouseButtonDown(0))
            UseToolGrid();
    }

    private void SelectTile()
    {
        _selectedTilePosition = _tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    private void Marker()
    {
        _markerManager.markedCellPosition = _selectedTilePosition;
    }

    private void CanSelectCheck()
    {
        Vector2 playerPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _selectable = Vector2.Distance(playerPosition, cameraPosition) < _maxDistance;
        _markerManager.ShowMarker(_selectable);
    }

    private void UseToolGrid()
    {
        if (_selectable)
        {
            TileBase tileBase = _tileMapReadController.GetTileBase(_selectedTilePosition);
            TileDataSo tileData = _tileMapReadController.GetTileData(tileBase);
            if (tileData != _plowableTiles) return;
            if (_cropsManager.Check(_selectedTilePosition))
            {
                _cropsManager.Seed(_selectedTilePosition);
            }
            else
            {
                _cropsManager.Plow(_selectedTilePosition);
            }
        }
    }

    private bool InteractionWithObject(bool mouseButtonDown)
    {
        var position = _playerRigidbody2D.position + _playerController.PlayerLookDirection * _offsetDistance;
        var colliders = Physics2D.OverlapCircleAll(position, _sizeRadiuInteractableArea);
        foreach (var itemCollider in colliders)
        {
            IObjectInteract interact = itemCollider.GetComponent<IObjectInteract>();
            
            if (interact == null) continue;
            
            //Interaction just after click
            if (mouseButtonDown)
            {
                interact.Interact();
            }
            //Highlight Object
            if (interact.IsHighlight)
            {
                _highlightController.Highlight(itemCollider.gameObject);
            }
            return true;
        }
        _highlightController.HideHighlight();
        return false;
    }
}
