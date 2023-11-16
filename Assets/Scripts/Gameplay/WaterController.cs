using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class WaterController : MonoBehaviour
{
    public delegate void Gameover();
    public event Gameover GameOver;
    [SerializeField] private Slider _uiWaterlevel;
    [SerializeField] private Slider _waterSlider;
    [SerializeField] private Slider _sunSlider;
    [SerializeField] private Slider _taskTopBorderSlider;
    [SerializeField] private Slider _taskDownBorderSlider;
    [SerializeField] private float _waterMoveSpeed;
    [SerializeField] private float _waterAccelerationSpeed;
    [SerializeField] private float _borderSize;
    [SerializeField] private float _rateOfBoundaryChange;
    [SerializeField] private float _smallestBorderSize;
    [SerializeField] private float _timerValue;
    [SerializeField] private float _waterRetentionTimer;
    [SerializeField] private float _waterRetentionTimeValue;
    [SerializeField] private float _waterSlowerAbilityValue;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _ScoreText;
    [SerializeField] private Button _x2ScoreButton;
    [SerializeField] private Button _slowingWaterButton;
    private float _scoreValue = 0;
    private bool _gameOverUpdator = true;
   
    public int GetScore() { return (int)_scoreValue; }
    private void Start()
    {
        _x2ScoreButton.onClick.AddListener(() => X2ScoreAbility());
        _slowingWaterButton.onClick.AddListener(() => WaterSlower());
        _waterRetentionTimer = _waterRetentionTimeValue;
        _timerValue = 10f;
        BorderSelect(_borderSize);
        StartCoroutine(Timer());
    }

    private void FixedUpdate()
    {
        WaterMover();
        LengthBetweenBordersUpdator();
        TimerTextAndValueUpdator();
        ScoreCounter();
        UiWaterLevelUpdator();
        ScoreTextUpdator();
    }

    private void WaterMover() 
    {
        if (_sunSlider.value < 0) { _waterSlider.value -= _waterMoveSpeed * Time.deltaTime; }
        if (_sunSlider.value > 0) { _waterSlider.value += _waterMoveSpeed * Time.deltaTime; }
    }

    private void BorderSelect(float lengthBetweenBorders) 
    {
        _taskDownBorderSlider.value = Random.Range(0, 100 - lengthBetweenBorders);
        _taskTopBorderSlider.value = -(_taskDownBorderSlider.value + lengthBetweenBorders);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timerValue);
        BorderRestart();
    }

    private void LengthBetweenBordersUpdator() 
    {
        if(_borderSize < _smallestBorderSize) {  _borderSize = _smallestBorderSize; }
    }

    private void TimerTextAndValueUpdator() 
    {
        if (_gameOverUpdator) 
        {
            _timerText.text = "Time left: " + (int)_timerValue;
            _timerValue -= Time.deltaTime;
        }
        
        if (_timerValue < 1 && _gameOverUpdator)
        {
           GameOver?.Invoke();
           StopAllCoroutines();
           int oldScore = PlayerPrefs.GetInt("PlayerScore", 0); // �������� ������ �������� ����� ��� 0, ���� ��� ���
           int newScore = oldScore + (int)_scoreValue; // ���������� ����� �������� � �������
           PlayerPrefs.SetInt("PlayerScore", newScore); // ��������� ����� �������� �����
           PlayerPrefs.Save(); // ����������� ��������� ���������
           _gameOverUpdator = false;
        }
    }

    private void ScoreCounter() 
    {
        
        if (_waterSlider.value > _taskDownBorderSlider.value && _waterSlider.value < System.Math.Abs(_taskTopBorderSlider.value)) 
        {
            _waterRetentionTimer -= Time.deltaTime;
            if (_waterRetentionTimer < 0) 
            {
                _scoreValue += 1;
                StopAllCoroutines();
                BorderRestart();
                _waterRetentionTimer = _waterRetentionTimeValue;
            }
        }
    }

    private void BorderRestart() 
    {
        _borderSize -= _rateOfBoundaryChange;
        _waterMoveSpeed += _waterAccelerationSpeed;
        BorderSelect(_borderSize);
        _timerValue = Random.Range(4, 10);
        StartCoroutine(Timer());
    }

    private void UiWaterLevelUpdator() { _uiWaterlevel.value = _waterSlider.value; }

    private void ScoreTextUpdator() { _ScoreText.text = "Score: " + (int)_scoreValue; }
    private void X2ScoreAbility() 
    {
        _scoreValue = _scoreValue * 2;
    }
    private void WaterSlower() 
    {
        _waterMoveSpeed -= _waterSlowerAbilityValue;
    }


}
