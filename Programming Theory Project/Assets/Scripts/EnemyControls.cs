using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : CharacterCore // INHERITANCE
{
    private ColorHandler colorHandler;
    private Color defaultColor;
    // Start is called before the first frame update
    protected override void Init()
    {
        speed = 1.0f;
        life = 1;
        attack = 1;
        moveRange = 5.0f;
        SetMoveRange();
        moveLeft = true;
        defaultColor = GetColor();
    }

    public override void EnterAction() // POLYMORPHISM
    {
        SetColor(Color.red);
    }

    public override void ExitAction() // POLYMORPHISM
    {
        SetColor(defaultColor);
    }


    Color GetColor() // ABSTRACTION // Hiding the method of getting a color
    {
        var colorHandler = GetComponentInChildren<ColorHandler>();
        if (colorHandler != null)
        {
            return colorHandler.GetColor();
        }
        else
        {
            return Color.white;
        }
    }

        void SetColor(Color c) // ABSTRACTION // Hiding the method of getting a color
    {
        var colorHandler = GetComponentInChildren<ColorHandler>();
        if (colorHandler != null)
        {
            colorHandler.SetColor(c);
        }
    }
}
