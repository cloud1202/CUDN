using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour, ILevel
{
    public void LevelSystem(int levelNumber)
    {
        if (GameManager.IsPause) return;
        GameManager.IntLevel = levelNumber;
        ItemGenerator.bombPer = 500 / GameManager.IntLevel;
        BoardGenerator.boardPer = 50 / GameManager.IntLevel;
        UiManager.Instance.DifficultyText(((GameManager.Level)GameManager.IntLevel).ToString("G"));
    }
}
