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

    bool isReady, isDead;
    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        currentState = GameState.MainMenu;
    }
    public void StartGame()
    {
        currentState = GameState.InGame;
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        OnGameEnded?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
