using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableIcon : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private IconType iconType;
    public Ingredients.Types CurrentIngredient;

    [Header("Sprites:")] 
    [SerializeField] private Sprite[] ingredientsSprites = new Sprite[6];

    // Componentes
    private Image _image;

    private enum IconType
    {
        Red,
        Green,
        Yellow
    }

    private void Start()
    {
        _image = GetComponent<Image>();

        Clean();
    }

    public void Change(Ingredients.Types ingredient)
    {
        CurrentIngredient = ingredient;
        SetImage();
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

    private void Clean()
    {
        CurrentIngredient = Ingredients.Types.Empty;
        _image.sprite = null;
        _image.color = new Color(255, 255, 255, 0f);
    }
}
