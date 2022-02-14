using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControls : CharacterCore // INHERITANCE
{
    // Start is called before the first frame update
    protected override void Init()
    {
        speed = 0.5f;
        life = 1;
        attack = 1;
        moveRange = 1.0f;
        SetMoveRange();
        moveLeft = true;
    }
    
    public override void EnterAction() // POLYMORPHISM
    {
        Talk();
    }

    private void Talk()
    {
        Debug.Log("Hello!");
    }
}
