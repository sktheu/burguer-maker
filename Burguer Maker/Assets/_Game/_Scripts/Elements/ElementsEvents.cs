using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementsEvents : MonoBehaviour
{
    [Header("Referências:")]
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject txtLost;
    [SerializeField] private GameObject txtTimeEnd;
    [SerializeField] private TextMeshProUGUI txtCurrentScore;
    [SerializeField] private TextMeshProUGUI txtLastScore;
    [SerializeField] private Score score;

    public void ShowEnd()
    {
        end.SetActive(true);
        if (score.CurrentScore == 0)
        {
            txtLost.SetActive(true);
            txtLastScore.text = "Pontos Anteriores: " + Score.LastScore;
        }
        else
        {
            txtTimeEnd.SetActive(true);
            txtCurrentScore.text = "Pontos: " + score.CurrentScore;
            txtLastScore.text = "Pontos Anteriores: " + Score.LastScore;
        }

        Score.LastScore = score.CurrentScore;
        Destroy(gameObject);
    }
}
