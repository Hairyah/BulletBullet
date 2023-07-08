using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    static public event Action OnGameStarted;
    public static event Action OnGameEnded;

    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }

    public GameState currentState;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }
}
