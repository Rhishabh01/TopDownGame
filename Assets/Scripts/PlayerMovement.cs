using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D playerrb;
    [SerializeField] private float MoveSpeed;
    private Vector2 Moveinput;
    private bool Wallhit;
    float speedX, speedY;
    void Start()
    {
        Application.targetFrameRate = 60;
        playerrb = GetComponent<Rigidbody2D>();
        Wallhit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerrb.linearVelocity = Moveinput * MoveSpeed;
        if (!Wallhit)
        {
            MoveSpeed = 12;
        }
        else
        {
            MoveSpeed = 5;
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Moveinput = context.ReadValue<Vector2>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            Wallhit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        { 
            Wallhit = false;
        }
    }
}
