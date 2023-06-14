using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private Ingredients.Types ingredient;
    [SerializeField] private TableIcon tableIconTarget;

    public void OnPressed()
    {
        tableIconTarget.Change(ingredient);
    }
}
