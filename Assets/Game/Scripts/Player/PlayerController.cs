using GameValley;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerDataSo _playerDataSo;
    
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    private WearController _wearController;

    private Vector2 _playerMoveVector = new Vector2(0,0);
    private Vector2 _playerLookDirection;
    private bool _isMoving = false;

    #region Properties

    public Vector2 PlayerLookDirection => _playerLookDirection;
    
    #endregion
    
    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _wearController = GetComponent<WearController>();
        gameObject.SetActive(false);
    }

    public void InitialiseGame()
    {
        _playerRigidbody2D.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        
        _playerMoveVector.x = horizontal;
        _playerMoveVector.y = vertical;

        SetAnimation("horizontal", horizontal);
        SetAnimation("vertical", vertical);

        _isMoving = horizontal != 0 || vertical != 0;
        SetAnimation("isMoving", _isMoving);
        
        if (_isMoving)
        {
            _playerLookDirection = _playerMoveVector.normalized;
            SetAnimation("lookHorizontal", horizontal);
            SetAnimation("lookVertical", vertical);
        }
    }

    private void SetAnimation(string name, float value)
    {
        _playerAnimator.SetFloat(name, value);
        _wearController.SetAnimation(name, value);
    }
    private void SetAnimation(string name, bool value)
    {
        _playerAnimator.SetBool(name, value);
        _wearController.SetAnimation(name, value);
    }

    private void FixedUpdate()
    {
        _playerRigidbody2D.velocity = _playerMoveVector * _playerDataSo.WalkSpeed;
    }
}
