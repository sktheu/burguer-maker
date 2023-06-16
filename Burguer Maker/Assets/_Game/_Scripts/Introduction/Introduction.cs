using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [Header("Referências:")]
    [SerializeField] private Animator elementsAnimator;
    [SerializeField] private AudioManager audioManager;

    // Components
    private TextMeshProUGUI _txtMP;

    private int _curCountDown = 3;

    private void Start()
    {
        _txtMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void ChangeText(string text)
    {
        _txtMP.text = text;
    }

    private void StartElements()
    {
        elementsAnimator.Play("Elements Start Animation");
        Destroy(gameObject);
    }

    private void CountDownSFX()
    {
        audioManager.PlaySFX("countdown " + _curCountDown);
        _curCountDown--;
    }

    private void StartMusic()
    {
        audioManager.PlayMusic("music");
    }
}
