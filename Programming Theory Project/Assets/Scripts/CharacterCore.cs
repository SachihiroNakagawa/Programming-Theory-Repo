using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCore : MonoBehaviour
{
    public GameObject player;
    public RigidBody charaRb;
    private ColorHandler colorHandler;
    [SerializeField] protected float speed;
    [SerializeField] protected int life;
    [SerializeField] protected int attack;
    [SerializeField] protected float moveRange;
    [SerializeField] protected float rangeX1;
    [SerializeField] protected float rangeX2;
    [SerializeField] protected bool moveLeft;
    [SerializeField] protected bool isActing;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        life = 1;
        attack = 1;
        moveRange = 5.0f;
        SetMoveRange();
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isActing)
        {
            ContinuousAction();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnterAction();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExitAction();
        }
    }

    protected void SetMoveRange()
    {
        rangeX1 = transform.position.x - moveRange;
        rangeX2 = transform.position.x + moveRange;
    }

    public void Move()
    {
        if (transform.position.X <= rangeX1)
        {
            moveLeft = false;
        }
        else if (transform.position.X >= rangeX2)
        {
            moveLeft = true;
        }

        Vector3 movement;
        if (moveLeft)
        {
            movement = Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            movement = Vector3.left * speed * Time.deltaTime * -1.0f;
        }
        transform.Translate(movement, Space.World);
    }

    public void EnterAction()
    {

    }
    public void ExitAction()
    {

    }

    public void ContinuousAction()
    {

    }

}
