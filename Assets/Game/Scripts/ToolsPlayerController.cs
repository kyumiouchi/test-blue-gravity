using UnityEngine;
using UnityEngine.Serialization;

public class ToolsPlayerController : MonoBehaviour
{
    [SerializeField] private float _offsetDistance = 1f;
    [SerializeField] private float _sizeRadiuInteractableArea = 1.2f;
    private PlayerController _playerController;
    private Rigidbody2D _playerRigidbody2D;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractionTool();
        }
    }

    private void InteractionTool()
    {
        var position = _playerRigidbody2D.position + _playerController.PlayerLookDirection * _offsetDistance;
        var colliders = Physics2D.OverlapCircleAll(position, _sizeRadiuInteractableArea);
        foreach (var itemCollider in colliders)
        {
            IObjectInteract interact = itemCollider.GetComponent<IObjectInteract>();
            
            if (interact == null) continue;
            
            interact.Interact();
            break;
        }
    }
}
