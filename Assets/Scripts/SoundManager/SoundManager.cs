using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonSound;
    [SerializeField] private AudioSource _backgroundMusic;

    private void Start()
    {
        PlayBackGroundMusic();
    }

    private void PlaySound()
    {
        _buttonSound.Play();
    }
    private void FixedUpdate()
    {
        CheckAllButtons();
    }
    private void CheckAllButtons() 
    {
        // �������� ��� ������ � �����
        Button[] buttons = FindObjectsOfType<Button>();

        // ��������� ���������� ��� ������ ������
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlaySound);
        }
    }
    private void PlayBackGroundMusic() 
    {
        if (_backgroundMusic.isPlaying)
        {
            Debug.Log("Background music is already playing.");
        }
        else
        {
            _backgroundMusic.Play();
        }
    }
}
