using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   InsputControls controls;
   Vector2 move;
   public float speed = 10;
 
   void Awake()
   {
       controls = new InsputControls();
       //controls.Player.Move.performed += context => 
       //                               SendMessage(context.ReadValue<Vector2>());
       controls.Player.Move.performed += context => move = 
                                      context.ReadValue<Vector2>();
       controls.Player.Move.canceled += context => move = Vector2.zero;
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
        if (MainManager.Instance != null)
        {
            SetColor(MainManager.Instance.PlayerColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
       transform.Translate(movement, Space.World);
    }

    void SetColor(Color c)
    {
        var colorHandler = GetComponentInChildren<ColorHandler>();
        if (colorHandler != null)
        {
            colorHandler.SetColor(c);
        }
    }
}
