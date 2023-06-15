using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private float[] colorLimits;

    [Header("Scriptable Objects:")]
    [SerializeField] private Burguer[] burguers = new Burguer[8];

    [Header("Mesa:")]
    [SerializeField] private TableIcon[] tableIcons = new TableIcon[3];

    [Header("Botões:")] 
    [SerializeField] private ButtonPosition[] buttons = new ButtonPosition[6];

    [Header("Feedback:")] 
    [SerializeField] private Feedback feedback;

    [Header("HUD:")] 
    [SerializeField] private Score score;

    [Header("Componentes:")] 
    [SerializeField] private Image[] images = new Image[4];
    [SerializeField] private TextMeshProUGUI txtMP;

    private int _iconScore;

    private float _currentTime;

    private bool _scoredRed, _scoredGreen, _scoredYellow;

    public static bool IsPlaying = false;

    private void Start()
    {
        StartCoroutine(SelectInitialBurguer(4f));
    }

    private void Update()
    {
        if (IsPlaying)
        {
            slider.maxValue = maxTime;
            Timer();

            if (_iconScore >= 3)
            {
                SelectBurguer(true);
            }
        }
    }

    private void SelectBurguer(bool scored, bool firstTime=false)
    {
        _scoredRed = false;
        _scoredGreen = false;
        _scoredYellow = false;

        if (!firstTime)
        {
            if (scored)
            {
                feedback.GainScore();
                score.Change(Score.Modifier.Increasing);
            }
            else
            {
                feedback.LostScore();
                score.Change(Score.Modifier.Decreasing);
            }

            foreach (var button in buttons)
            {
                button.Realocate();
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
                SelectBurguer(false);
            }
            else if (!_scoredRed)
            {
                _iconScore++;
                _scoredRed = true;
            }
        }
        else if (iconType == TableIcon.Types.Green)
        {
            if (ingredient != currentBurguer.ingredients[1])
            {
                SelectBurguer(false);
            }
            else if (!_scoredGreen)
            {
                _iconScore++;
                _scoredGreen = true;
            }
        }
        else
        {
            if (ingredient != currentBurguer.ingredients[2])
            {
                SelectBurguer(false);
            }
            else if (!_scoredYellow)
            {
                _iconScore++;
                _scoredYellow = true;
            }
        }
    }

    private void Timer()
    {
        _currentTime -= Time.deltaTime;
        slider.value = _currentTime * slider.maxValue / slider.maxValue;

        if (_currentTime >= colorLimits[0])
            fillImage.color = fillColors[0];
        else if (_currentTime >= colorLimits[1])
            fillImage.color = fillColors[1];
        else if (_currentTime >= colorLimits[2])
            fillImage.color = fillColors[2];
        else
            SelectBurguer(false);
    }

    private IEnumerator SelectInitialBurguer(float t)
    {
        yield return new WaitForSeconds(t);
        IsPlaying = true;
        SelectBurguer(false, true);
    }
}
