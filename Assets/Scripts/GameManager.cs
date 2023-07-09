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
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
