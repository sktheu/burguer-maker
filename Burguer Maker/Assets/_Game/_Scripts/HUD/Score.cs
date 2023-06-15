using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private int increment;
    [SerializeField] private int decrement;
    [SerializeField] private int initialValue;

    private int _currentScore;

    public enum Modifier
    {
        Increasing,
        Decreasing
    }

    // Componentes
    private TextMeshProUGUI _txtMP;

    private void Start()
    {
        _txtMP = GetComponent<TextMeshProUGUI>();

        _currentScore = initialValue;
        _txtMP.text = "Pontos: " + _currentScore;
    }

    public void Change(Score.Modifier modifier)
    {
        if (modifier == Modifier.Increasing)
        {
            _currentScore += increment;
        }
        else
        {
            _currentScore -= decrement;
            if (_currentScore <= 0)
            {
                _currentScore = 0;
                //TODO: GameOVER
            }
        }

        _txtMP.text = "Pontos: " + _currentScore;
    }
}
