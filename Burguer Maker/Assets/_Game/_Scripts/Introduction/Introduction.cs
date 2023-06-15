using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [Header("Referências:")]
    [SerializeField] private Animator elementsAnimator;

    // Components
    private TextMeshProUGUI _txtMP;

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
}
