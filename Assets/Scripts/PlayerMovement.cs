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
    [SerializeField] private ParticleSystem SpeedParticles;
    void Start()
    {
        SpeedParticles.Play();
        Application.targetFrameRate = 60;
        playerrb = GetComponent<Rigidbody2D>();
        Wallhit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Applies Force locally not for the world
        playerrb.AddRelativeForce(Vector2.up * Moveinput * MoveSpeed,ForceMode2D.Force);
        
        if (!Wallhit)
        {
            MoveSpeed = 12;
        }
        else
        {
            MoveSpeed = 5;
        }
        if(Moveinput.y > 0)
        {
            Particles(SpeedParticles, true);
        }
        else
        {
            Particles(SpeedParticles, false);
        }

        if (Moveinput.x < 0)
        {
            playerrb.AddTorque(2f); // rotates left

        }
        else if (Moveinput.x > 0)
        {
            playerrb.AddTorque(-2f); //rotates right
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Takes input (WASD and converts into 1and -1 depedning upon input)
        Moveinput = context.ReadValue<Vector2>();   
    }

    private void Particles(ParticleSystem particle, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particle.emission;
        emissionModule.enabled = enabled;
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
