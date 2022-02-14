using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControls : CharacterCore // INHERITANCE
{
    // Start is called before the first frame update
    override void Start()
    {
        speed = 5.0f;
        life = 1;
        attack = 1;
        moveRange = 5.0f;
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
