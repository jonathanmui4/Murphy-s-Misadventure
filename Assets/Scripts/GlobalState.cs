using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState
{
    private static int level = 4;
    private static bool isGameOver = false;

    public static void SetLevel(int newLevel)
    {
        level = newLevel;
    }

    public static void IncrementLevel()
    {
        level++;
    }

    public static int GetLevel()
    {
        return level;
    }

    public static void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }

    public static bool IsGameOver()
    {
        return isGameOver;
    }
}
