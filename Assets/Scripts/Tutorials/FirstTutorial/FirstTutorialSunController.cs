using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstTutorialSunController : MonoBehaviour
{
    [SerializeField] private Slider _sunSlider;
    [SerializeField] private Slider _waterSlider;
    [SerializeField] private Slider _underSunSlider;
    [SerializeField] private float _sunMoveSpeed;
    [SerializeField] private float _sunRotationSpeed;
    [SerializeField] private GameObject _sun;
    private float _direction = 1;
    private void FixedUpdate()
    {
        SunMover();
        SliderUIUpdator();
    }
    private void SunMover()
    {
        if(_sunSlider.value == _sunSlider.maxValue) 
        {
            _direction = -1;
        }
        if (_sunSlider.value == _sunSlider.minValue)
        {
            _direction = 1;
        }
        _sunSlider.value += _direction * (_sunMoveSpeed * Time.deltaTime);
        _sun.transform.Rotate(Vector3.back, _direction * _sunRotationSpeed * Time.deltaTime);
    }
    private void SliderUIUpdator() 
    {
        _waterSlider.value = _sunSlider.value;
        _underSunSlider.value = _sunSlider.value;
    }

}
