using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private float startTime;

    [Header("Referências:")] 
    [SerializeField] private Animator elementsAnimator;
    
    // Componentes
    private TextMeshProUGUI _txtMP;

    private float _currentTime;

    private void Start()
    {
        _txtMP = GetComponent<TextMeshProUGUI>();
        _currentTime = startTime;
        SetTimerText();
    }

    private void Update()
    {
        if (_currentTime > 0f)
        {
            _currentTime -= Time.deltaTime;
            SetTimerText();
        }
        else
        {
            _currentTime = 0;
            SetTimerText();
            BurguerObjective.IsPlaying = false;
            elementsAnimator.Play("Elements End Animation");
        }
    }

    private void SetTimerText()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60f);
        int seconds = Mathf.FloorToInt(_currentTime % 60f); 

        string timerString = string.Format("Tempo: {0:00}:{1:00}", minutes, seconds);

        _txtMP.text = timerString;
    }
}