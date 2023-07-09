using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public CanvasGroup MainMenu;
    public CanvasGroup GamePlay;
    public CanvasGroup GameOverMenu;


    public GameObject StartGameUI;

    //public GameObject RestartGame;
    //public GameObject GameOverPanel;

    private AudioManager audioManager;


    private void Awake()
    {
        Instance = this;

        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameEnded += OnGameEnded;
    }

    private void Start()
    {
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

        //GameOverPanel.transform.localScale = Vector3.zero;
        //RestartGame.transform.localScale = Vector3.zero;

        //GameOverMenu.DOFade(1, 0.4f).SetDelay(0.5f)
        //    .OnComplete(() => GameOverPanel.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)
        //    .OnComplete(() => RestartGame.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)));
    }

    public void TriggerStartGame()
    {
        StartGameUI.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
