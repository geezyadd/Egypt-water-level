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

    [SerializeField] private Button _firstTutorialCloseButton;
    [SerializeField] private Button _secondTutorialCloseButton;
    [SerializeField] private Button _thirdTutorialCloseButton;
    [SerializeField] private GameObject _firstTutorial;
    [SerializeField] private GameObject _secondTutorial;
    [SerializeField] private GameObject _thirdTutorial;

    private void Start()
    {
        Pause(true);
        _pauseButton.onClick.AddListener(() => PauseMenu(true));
        _resumeGameButton.onClick.AddListener(() => PauseMenu(false));
        _restartButton.onClick.AddListener(() => SceneLoader(SceneManager.GetActiveScene().name));
        _looseCanvasRestartButton.onClick.AddListener(() => SceneLoader(SceneManager.GetActiveScene().name));
        _backToMenuButton.onClick.AddListener(() => SceneLoader("StartMenuScene"));
        _backToMenuButton.onClick.AddListener(() => PauseMenu(false));
        _looseCanvasBackToMenuButton.onClick.AddListener(() => SceneLoader("StartMenuScene"));
        _waterController.GameOver += SetLooseCanvasActive;
        _firstTutorialCloseButton.onClick.AddListener(() => CanvasSetActive(_firstTutorial, false));
        _firstTutorialCloseButton.onClick.AddListener(() => CanvasSetActive(_secondTutorial, true));
        _secondTutorialCloseButton.onClick.AddListener(() => CanvasSetActive(_secondTutorial, false));
        _secondTutorialCloseButton.onClick.AddListener(() => CanvasSetActive(_thirdTutorial, true));
        _thirdTutorialCloseButton.onClick.AddListener(() => CanvasSetActive(_thirdTutorial, false));
        _thirdTutorialCloseButton.onClick.AddListener(() => PauseMenu(false));
    }
    private void SetLooseCanvasActive() 
    {
        //_looseCanvas.SetActive(true);
        CanvasSetActive(_looseCanvas, true);
        _thisGameScoreText.text = "Score of this game: " + _waterController.GetScore();
    }
    private void PauseMenu(bool isPause)
    {
        //_pauseCanvas.SetActive(isPause);
        CanvasSetActive(_pauseCanvas, isPause);
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
    private void CanvasSetActive( GameObject canvas, bool setActive) 
    {
        canvas.SetActive(setActive);
    }
}
