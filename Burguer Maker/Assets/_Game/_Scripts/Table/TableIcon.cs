using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableIcon : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private TableIcon.Types iconType;
    public Ingredients.Types CurrentIngredient;

    [Header("Sprites:")] 
    [SerializeField] private Sprite[] ingredientsSprites = new Sprite[6];

    // Referências
    private static BurguerObjective _burguerObjective;

    // Componentes
    private Image _image;

    public enum Types
    {
        Red,
        Green,
        Yellow
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _burguerObjective = GameObject.FindGameObjectWithTag("BurguerObjective").GetComponent<BurguerObjective>();
    }

    public void Change(Ingredients.Types ingredient)
    {
        CurrentIngredient = ingredient;
        SetImage();
        _burguerObjective.CompareIcons(CurrentIngredient, iconType);
    }

    public void SetImage()
    {
        _image.color = Color.white;

        switch (CurrentIngredient)
        {
            case Ingredients.Types.Ketchup:
                _image.sprite = ingredientsSprites[0];
                break;

            case Ingredients.Types.Mostard:
                _image.sprite = ingredientsSprites[1];
                break;

            case Ingredients.Types.Lettuce:
                _image.sprite = ingredientsSprites[2];
                break;

            case Ingredients.Types.Onion:
                _image.sprite = ingredientsSprites[3];
                break;

            case Ingredients.Types.Cheese:
                _image.sprite = ingredientsSprites[4];
                break;

            case Ingredients.Types.Bacon:
                _image.sprite = ingredientsSprites[5];
                break;
        }
    }

    public void Clean()
    {
        CurrentIngredient = Ingredients.Types.Empty;
        _image.sprite = null;
        _image.color = new Color(255, 255, 255, 0f);
    }
}
