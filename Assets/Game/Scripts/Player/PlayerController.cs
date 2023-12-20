using System;
using System.Collections;
using System.Collections.Generic;
using GameValley;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerDataSo _playerDataSo;
    
    /// <summary>
    /// Rigidbody2D component of the player.
    /// </summary>
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;

    private Vector2 _playerMoveVector = new Vector2(0,0);
    private Vector2 _playerLookDirection;
    private bool _isMoving = false;

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public void InitialiseGame()
    {
        _playerRigidbody2D.gameObject.SetActive(true);

        ResetPlayerPosition();
    }

    private void ResetPlayerPosition()
    {
        
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _playerMoveVector.x = horizontal;
        _playerMoveVector.y = vertical;
        _playerAnimator.SetFloat("horizontal", horizontal);
        _playerAnimator.SetFloat("vertical", vertical);

        _isMoving = horizontal != 0 || vertical != 0;
        _playerAnimator.SetBool("isMoving", _isMoving);
        if (_isMoving)
        {
            _playerLookDirection = _playerMoveVector.normalized;
            _playerAnimator.SetFloat("lookHorizontal", horizontal);
            _playerAnimator.SetFloat("lookVertical", vertical);
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody2D.velocity = _playerMoveVector * _playerDataSo.WalkSpeed;
    }
}
