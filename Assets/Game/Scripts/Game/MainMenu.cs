using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Delegate triggered when the Start Game button is pressed.
    /// </summary>
    public Action StartGame = delegate { };

    /// <summary>
    /// Begins the process of starting the game.
    /// </summary>
    public void StartGameButtonPressed()
    {
        //Audio
        StartGame();
    }
}
