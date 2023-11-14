using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalScore;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartScoreButton;
    private void Start()
    {
        TotalScoreUpdator();
        _playButton.onClick.AddListener(() => LoadGamePlayScene());
        _restartScoreButton.onClick.AddListener(() => RestartScoreValue());
    }
    private void TotalScoreUpdator()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");
        _totalScore.text = "Total score: " + score;
    }
    private void LoadGamePlayScene() 
    {
        // Получаем индекс текущей активной сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загружаем следующую сцену по порядку индексов сцен
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void RestartScoreValue() 
    {
        PlayerPrefs.DeleteAll(); //удалить
        PlayerPrefs.Save();
        TotalScoreUpdator();
    }
}
