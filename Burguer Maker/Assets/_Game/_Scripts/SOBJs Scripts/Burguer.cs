using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burguer", menuName = "Scriptable Objects/Burguer")]
public class Burguer : ScriptableObject
{
    public string Name;

    [Header("Sprites:")] 
    public Sprite[] sprites = new Sprite[4];

    [Header("Ingredientes:")]
    public Ingredients.Types[] ingredients = new Ingredients.Types[3];
}
