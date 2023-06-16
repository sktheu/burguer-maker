using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [Header("Configura��es:")]
    [SerializeField] private Ingredients.Types ingredient;
    [SerializeField] private TableIcon tableIconTarget;

    [Header("Refer�ncias:")] 
    [SerializeField] private AudioManager audioManager;

    public void OnPressed()
    {
        audioManager.PlaySFX("button " + Random.Range(1, 3));
        tableIconTarget.Change(ingredient);
    }
}
