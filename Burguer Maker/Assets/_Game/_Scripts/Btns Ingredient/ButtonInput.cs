using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private Ingredients.Types ingredient;
    [SerializeField] private TableIcon tableIconTarget;

    [Header("Referências:")] 
    [SerializeField] private AudioManager audioManager;

    public void OnPressed()
    {
        audioManager.PlaySFX("button " + Random.Range(1, 3));
        tableIconTarget.Change(ingredient);
    }
}
