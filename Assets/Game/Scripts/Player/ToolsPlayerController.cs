using UnityEngine;

public class ToolsPlayerController : MonoBehaviour
{
    [SerializeField] private HighlightController _highlightController;
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] private float _sizeRadiuInteractableArea = 1.2f;
    [SerializeField] private MarkerManager _markerManager;
    [SerializeField] private TileMapReadController _tileMapReadController;
    private PlayerController _playerController;
    private Rigidbody2D _playerRigidbody2D;
    private bool _isHighlight;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Marker();
        InteractionWithObject(Input.GetMouseButtonDown(0));
    }

    private void Marker()
    {
        Vector3Int gridPosition = _tileMapReadController.GetGridPosition(Input.mousePosition, true);
        _markerManager.markedCellPosition = gridPosition;
    }

    private void InteractionWithObject(bool mouseButtonDown)
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
            return;
        }
        _highlightController.HideHighlight();
    }
}
