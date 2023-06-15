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

    [Header("Referências:")] 
    [SerializeField] private Animator elementsAnimator;

    [HideInInspector] public int CurrentScore { get; private set; }
    public static int LastScore = 0;

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

        CurrentScore = initialValue;
        _txtMP.text = "Pontos: " + CurrentScore;
    }

    public void Change(Score.Modifier modifier)
    {
        if (modifier == Modifier.Increasing)
        {
            CurrentScore += increment;
        }
        else
        {
            CurrentScore -= decrement;
            if (CurrentScore <= 0)
            {
                CurrentScore = 0;
                BurguerObjective.IsPlaying = false;
                elementsAnimator.Play("Elements End Animation");
            }
        }

        _txtMP.text = "Pontos: " + CurrentScore;
    }
}
