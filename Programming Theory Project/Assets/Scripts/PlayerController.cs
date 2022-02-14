using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InsputControls controls;
    private Rigidbody playerRb;
    private Vector2 move;
    public float speed = 10;
    public float jumpForce = 500;
    private bool isOnGround = true;

    void Awake()
    {
        controls = new InsputControls();
        //controls.Player.Move.performed += context => 
        //                               SendMessage(context.ReadValue<Vector2>());
        controls.Player.Move.performed += context => move = 
                                      context.ReadValue<Vector2>();
        controls.Player.Move.canceled += context => move = Vector2.zero;
        controls.Player.Fire.performed += context => FireButton();
   }
 
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        if (MainManager.Instance != null)
        {
            SetColor(MainManager.Instance.PlayerColor);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        
        float angle = Quaternion.FromToRotation(transform.forward, movement).eulerAngles.y;
        transform.Rotate(0, angle, 0);
    }

    void SetColor(Color c)
    {
        var colorHandler = GetComponentInChildren<ColorHandler>();
        if (colorHandler != null)
        {
            colorHandler.SetColor(c);
        }
    }

    private void FireButton()
    {
        if (isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
