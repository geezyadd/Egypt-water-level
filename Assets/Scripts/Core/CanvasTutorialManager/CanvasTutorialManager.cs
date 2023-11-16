using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasTutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _firstTutorial;
    [SerializeField] private GameObject _secondTutorial;
    [SerializeField] private GameObject _thirdTutorial;
    [SerializeField] private Button _firstTutorialCloseButton;
    [SerializeField] private Button _secondTutorialCloseButton;
    [SerializeField] private Button _thirdTutorialCloseButton;
    [SerializeField] private Button _skipTutorialButton;
    // Start is called before the first frame update
    void Start()
    {
        _firstTutorialCloseButton.onClick.AddListener(() => GameObjectSetActive(_firstTutorial, false));
        _firstTutorialCloseButton.onClick.AddListener(() => GameObjectSetActive(_secondTutorial, true));
        _secondTutorialCloseButton.onClick.AddListener(() => GameObjectSetActive(_secondTutorial, false));
        _secondTutorialCloseButton.onClick.AddListener(() => GameObjectSetActive(_thirdTutorial, true));
        _thirdTutorialCloseButton.onClick.AddListener(() => SceneLoader("GameplayScene"));
        _skipTutorialButton.onClick.AddListener(() => SceneLoader("GameplayScene"));
    }
    private void GameObjectSetActive(GameObject tutorial, bool setActive)
    {
        tutorial.SetActive(setActive);
    }
    private void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
