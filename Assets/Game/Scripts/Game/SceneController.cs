using System;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// States of the game.
    /// </summary>
    private enum GameStates
    {
        /// <summary>
        /// Initial setup.
        /// </summary>
        Init,

        /// <summary>
        /// Player is in the main menu.
        /// </summary>
        MainMenu,

        /// <summary>
        /// Player is playing the game.
        /// </summary>
        Game
    }
    
    private GameStates state = GameStates.Init;
    [SerializeField] private MainMenu mainMenu = null;
    [SerializeField] private Game game = null;
    
    private void Start()
    {
        mainMenu.StartGame += OnStartGame;
        game.gameComplete += OnGameComplete;
        
        State = GameStates.MainMenu;
    }

    /// <summary>
    /// Triggered when the player presses the start game button.
    /// </summary>
    private void OnStartGame()
    {
        State = GameStates.Game;
    }
    /// <summary>
    /// Triggered when the player completes a game.
    /// </summary>
    private void OnGameComplete()
    {
        State = GameStates.MainMenu;
    }
    
    
    /// <summary>
    /// State of the game. Changing the state will transition the game.
    /// </summary>
    private GameStates State
    {

        get => state;

        set
        {
            // Cannot return to init.
            if (value == GameStates.Init)
            {
                throw new ArgumentException("Cannot return to init state.");
            }

            state = value;

            switch (state)
            {
                case GameStates.MainMenu:
                    mainMenu.gameObject.SetActive(true);
                    game.gameObject.SetActive(false);
                    break;

                case GameStates.Game:
                    mainMenu.gameObject.SetActive(false);
                    game.gameObject.SetActive(true);
                    break;

                case GameStates.Init:
                // Intentional fallthrough. Init isn't supported but will be explicitly handled above.
                default:
                    throw new ArgumentOutOfRangeException($"State machine doesn't support state {state}.");
            }
        }
    }
}
