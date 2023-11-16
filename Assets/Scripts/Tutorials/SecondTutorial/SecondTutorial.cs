using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondTutorial : MonoBehaviour
{
    [SerializeField] private Slider _waterSlider;
    [SerializeField] private float _waterSliderSpeed;
    private float _direction = 1;

    private void FixedUpdate()
    {
        SunMover();
    }
    private void SunMover()
    {
        if (_waterSlider.value == _waterSlider.maxValue)
        {
            _direction = -1;
        }
        if (_waterSlider.value == _waterSlider.minValue)
        {
            _direction = 1;
        }
        _waterSlider.value += _direction * (_waterSliderSpeed * Time.deltaTime);
    }
}
