using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCore : MonoBehaviour
{
    public GameObject player;
    protected Rigidbody charaRb;
    [SerializeField] protected float speed;
    [SerializeField] protected int life;
    [SerializeField] protected int attack;
    [SerializeField] protected float moveRange;
    protected float rangeX1;
    protected float rangeX2;
    protected bool moveLeft;
    [SerializeField] protected bool isActing;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        charaRb = GetComponent<Rigidbody>();
        speed = 1.0f;
        life = 1;
        attack = 1;
        moveRange = 5.0f;
        SetMoveRange();
        moveLeft = true;
    }

    void FixedUpdate()
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

    public virtual void Move()
    {
        if (transform.position.x <= rangeX1)
        {
            moveLeft = false;
        }
        else if (transform.position.x >= rangeX2)
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
        
        float angle = Quaternion.FromToRotation(transform.forward, movement).eulerAngles.y;
        transform.Rotate(0, angle, 0);
    }

    public virtual void EnterAction()
    {

    }
    public virtual void ExitAction()
    {

    }

    public virtual void ContinuousAction()
    {

    }

}
