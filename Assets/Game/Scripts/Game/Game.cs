using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    /// <summary>
    /// Delegate triggered when the game is complete.
    /// </summary>
    public Action gameComplete = delegate { };

    [SerializeField] private PlayerController _PlayerController;

    private void Start()
    {
        InitialiseGame();
    }

    public void InitialiseGame()
    {
        _PlayerController.InitialiseGame();
    }
}
