using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilityReseter : MonoBehaviour
{
    [SerializeField] private float _respawnDelay;
    [SerializeField] private float _yPositionRespawn;
    private RectTransform _rectTransform;
    private Vector2 _startPosition;
    private Button _abilityButton;
    private Image _buttonImage;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _abilityButton = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _abilityButton.onClick.AddListener(() => OnClickButton());
    }
    private void FixedUpdate()
    {
        if(_rectTransform.position.y < _yPositionRespawn) 
        {
            OnClickButton();
        }
    }
    private void ResetPosition() { transform.position = _startPosition; }
    private void OnClickButton() 
    {
        _rigidbody.simulated = false;
        _buttonImage.enabled = false;
        _abilityButton.enabled = false;
        ResetPosition();
        StartCoroutine(StartDelayedTask());
    }
    private IEnumerator StartDelayedTask()
    {
        yield return new WaitForSeconds(_respawnDelay);
        _buttonImage.enabled = true;
        _abilityButton.enabled = true;
        _rigidbody.simulated = true;
        _rigidbody.velocity = Vector2.zero;
    }
}
