using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControls : CharacterCore // INHERITANCE
{
    private bool isRunAway;
    // Start is called before the first frame update
    override void Start()
    {
        speed = 5.0f;
        life = 1;
        attack = 1;
        moveRange = 5.0f;
        SetMoveRange();
        moveLeft = true;

        isRunAway = false;
    }
    public override void Move() // POLYMORPHISM
    {
        Vector3 dif = transform.position - player.transform.position;
        if (dif.magnitude > 5.0f)
        {
            isRunAway = false;
        }
        if (isRunAway)
        {
            Vector3 move = dif;
            move.y = 0;
            move.z = 0;
            transform.Translate(move.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            Move();
        }
    }

    public override void EnterAction() // POLYMORPHISM
    {
        isRunAway = true;
    }
}
