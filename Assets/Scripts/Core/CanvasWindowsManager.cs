using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.SocialPlatforms.Impl;

public class CanvasWindowsManager : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private Button _restartButton;

    [SerializeField] private Button _resumeGameButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _looseCanvasBackToMenuButton;
    [SerializeField] private Button _looseCanvasRestartButton;

    [SerializeField] private GameObject _looseCanvas;
    [SerializeField] private WaterController _waterController;

    [SerializeField] private TMP_Text _thisGameScoreText;

    private void Start()
    {
        _pauseButton.onClick.AddListener(() => PauseMenu(true));
        _resumeGameButton.onClick.AddListener(() => PauseMenu(false));
        _restartButton.onClick.AddListener(() => SceneLoader(SceneManager.GetActiveScene().name));
        _looseCanvasRestartButton.onClick.AddListener(() => SceneLoader(SceneManager.GetActiveScene().name));
        _backToMenuButton.onClick.AddListener(() => SceneLoader("StartMenuScene"));
        _looseCanvasBackToMenuButton.onClick.AddListener(() => SceneLoader("StartMenuScene"));
        _waterController.GameOver += SetLooseCanvasActive;
    }
    private void SetLooseCanvasActive() 
    {
        _looseCanvas.SetActive(true);
        _thisGameScoreText.text = "Score of this game: " + _waterController.GetScore();
    }
    private void PauseMenu(bool isPause)
    {
        _pauseCanvas.SetActive(isPause);
        Pause(isPause);
    }
    private void Pause(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f; 
        }
    }
    private void SceneLoader(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
