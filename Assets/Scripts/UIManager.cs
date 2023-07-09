using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public CanvasGroup MainMenu;
    public CanvasGroup GamePlay;
    public CanvasGroup GameOverMenu;
    public GameObject PauseMenu;
    public bool gameIsPaused = false;


    public GameObject StartGameUI;

    public GameObject GameOverPanel;

    private AudioManager audioManager;

    public Text InGameScoreText;
    public Text GameOverScoreText;
    public Text GameOverHightScoreText;


    private void Awake()
    {
        Instance = this;

        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameEnded += OnGameEnded;
    }

    private void Start()
    {
        PauseMenu.SetActive(false);

        MainMenu.alpha = 1.0f;
        GamePlay.alpha = 0f;
        GameOverMenu.alpha = 0f;

        GameOverMenu.gameObject.SetActive(false);
        GamePlay.gameObject.SetActive(false);

        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("MenuMusic");
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameEnded -= OnGameEnded;
    }

    public void OnGameStarted()
    {
        MainMenu.transform.DOPunchScale(Vector2.up * 0.25f, 0.2f);
        MainMenu.DOFade(1, 0.2f).OnComplete(() => MainMenu.gameObject.SetActive(false));
        GamePlay.gameObject.SetActive(true);
        GamePlay.DOFade(1, 0.2f);

        audioManager.Stop("MenuMusic");
        audioManager.Play("Wind");
        audioManager.Play("ShootSlowMo");
        audioManager.Play("ThemeMusic");
    }
    public void OnGameEnded()
    {
        GamePlay.DOFade(0, 0.2f).OnComplete(() => GamePlay.gameObject.SetActive(false));
        GameOverMenu.gameObject.SetActive(true);

        GameOverScoreText.text = ScoreManager.Instance.score.ToString();
        GameOverHightScoreText.text = ScoreManager.Instance.hightScore.ToString();

        GameOverPanel.transform.localScale = Vector3.zero;

        GameOverMenu.DOFade(1, 0.4f).SetDelay(0.5f)
            .OnComplete(() => GameOverPanel.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack));
    }

    public void TriggerStartGame()
    {
        StartGameUI.SetActive(false);
        GameManager.Instance.StartGame();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void UpdateScore(int score)
    {
        InGameScoreText.text = score.ToString();
        InGameScoreText.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
    }
}
