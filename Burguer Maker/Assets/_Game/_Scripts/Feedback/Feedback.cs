using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private float hideInterval;
    [SerializeField] private Color[] colors;

    // Referências
    private Animator _mainCameraAnimator;

    // Components
    private Image _img;

    private void Start()
    {
        _img = GetComponent<Image>();
    }

    public void GainScore()
    {
        _img.enabled = true;
        _img.color = colors[0];
        StartCoroutine(HideImage(hideInterval));
    }

    public void LostScore()
    {
        _img.enabled = true;
        _img.color = colors[1];
        StartCoroutine(HideImage(hideInterval));
    }

    private IEnumerator HideImage(float t)
    {
        yield return new WaitForSeconds(t);
        _img.enabled = false;
    }
}
