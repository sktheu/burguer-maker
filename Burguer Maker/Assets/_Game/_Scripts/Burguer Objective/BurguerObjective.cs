using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BurguerObjective : MonoBehaviour
{
    
    [SerializeField] private Burguer currentBurguer;

    [Header("Timer:")] 
    [SerializeField] private float maxTime;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color[] fillColors;

    [Header("Scriptable Objects:")]
    [SerializeField] private Burguer[] burguers = new Burguer[8];

    [Header("Mesa:")]
    [SerializeField] private TableIcon[] tableIcons = new TableIcon[3];

    [Header("Botões:")] 
    [SerializeField] private ButtonPosition[] buttons = new ButtonPosition[6];

    [Header("Feedback:")] 
    [SerializeField] private Feedback feedback;

    [Header("Componentes:")] 
    [SerializeField] private Image[] images = new Image[4];
    [SerializeField] private TextMeshProUGUI txtMP;

    private int _iconScore;

    private float _currentTime;

    private void Start()
    {
        SelectBurguer(false, true);
    }

    private void Update()
    {
        slider.maxValue = maxTime;
        Timer();

        if (_iconScore >= 3)
        {
            SelectBurguer(true);
            // Todo: Pontuar
        }
    }

    private void SelectBurguer(bool scored, bool firstTime=false)
    {
        if (!firstTime)
        {
            if (scored)
                feedback.GainScore();
            else
            {
                feedback.LostScore();
                foreach (var button in buttons)
                {
                    button.Realocate();
                }
            }
        }
        
        _currentTime = maxTime;
        _iconScore = 0;

        foreach (var tableIcon in tableIcons)
        {
            tableIcon.Clean();
        }

        currentBurguer = burguers[Random.Range(0, burguers.Length)];

        for (int i = 0; i < 4; i++)
        {
            images[i].sprite = currentBurguer.sprites[i];
        }

        txtMP.text = currentBurguer.Name;
    }

    public void CompareIcons(Ingredients.Types ingredient, TableIcon.Types iconType)
    {
        if (iconType == TableIcon.Types.Red)
        {
            if (ingredient != currentBurguer.ingredients[0])
            {
                SelectBurguer(true);
                feedback.LostScore();
            }
            else
                _iconScore++;
        }
        else if (iconType == TableIcon.Types.Green)
        {
            if (ingredient != currentBurguer.ingredients[1])
                SelectBurguer(false);
            else
                _iconScore++;
        }
        else
        {
            if (ingredient != currentBurguer.ingredients[2])
                SelectBurguer(false);
            else
                _iconScore++;
        }
    }

    private void Timer()
    {
        _currentTime -= Time.deltaTime;
        slider.value = _currentTime * slider.maxValue / slider.maxValue;

        if (_currentTime >= 6f)
            fillImage.color = fillColors[0];
        else if (_currentTime >= 4f)
            fillImage.color = fillColors[1];
        else if (_currentTime >= 0f)
            fillImage.color = fillColors[2];
        else
            SelectBurguer(false);
    }
}
