using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burguer", menuName = "Scriptable Objects/Burguer")]
public class Burguer : ScriptableObject
{
    public string Name;

    [Header("Sprites:")] 
    public Sprite[] sprites;

    [Header("Ingredientes:")]
    public Ingredients.Red RedIngredient;
    public Ingredients.Green GreenIngredient;
    public Ingredients.Yellow YelloIngredient;
}
