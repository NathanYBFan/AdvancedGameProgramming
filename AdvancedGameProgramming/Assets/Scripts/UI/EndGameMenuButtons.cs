using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenuButtons : MonoBehaviour
{
    public void PlayAgainButtonPressed()
    {
        GameManager._Instance.StartLoadLevel(GameManager._Instance.LevelNames[1]);
        // Reset player stats
        GameManager._Instance.StartNewGame();
        SaveGameManager._Instance.saveGamePresent = false;
    }

    public void ToMainMenuPressed()
    {
        GameManager._Instance.StartLoadLevel(GameManager._Instance.LevelNames[0]);
        // Reset player stats
        GameManager._Instance.StartNewGame();
        SaveGameManager._Instance.saveGamePresent = false;
    }
}
