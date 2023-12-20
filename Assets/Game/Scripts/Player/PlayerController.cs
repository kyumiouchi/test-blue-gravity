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
    [SerializeField] private Rigidbody2D _playerRigidbody2D;

    private Vector2 _playerMoveVector;

    private void Awake()
    {
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
        _playerMoveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        _playerRigidbody2D.velocity = _playerMoveVector * _playerDataSo.WalkSpeed;
    }
}
