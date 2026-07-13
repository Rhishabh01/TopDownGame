using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D playerrb;
    [SerializeField] private float MoveSpeed;
    private Vector2 Moveinput;
    public bool Wallhit;
    private float cooltime;
    public bool TimeFail;
    public bool Completed;
    [SerializeField] public int health;
    [SerializeField] private ParticleSystem SpeedParticles;
    public int KeyValue;
    private Key keys;
    
    public int currkeyval;
    void Start()
    {
      
        health = 3;
        SpeedParticles.Play();
        Application.targetFrameRate = 60;
        playerrb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

        //Applies Force locally not for the world
        if(health > 0 && Completed == false && TimeFail == false)
        {
        
            if (!Wallhit)
            {
                Movement();
            }
            else
            {
                WallHit();  
            }
        }
        else
        {
            
            Particles(SpeedParticles, false);
        }
        
        
    
    }

    private void Movement()
    {
        playerrb.AddRelativeForce(Vector2.up * Moveinput * MoveSpeed, ForceMode2D.Force);
        MoveSpeed = 12;

        if (Moveinput.x < 0)
        {
            playerrb.AddTorque(2f); // rotates left

        }
        else if (Moveinput.x > 0)
        {
            playerrb.AddTorque(-2f); //rotates right

        }
        if (Moveinput.y > 0)
        {
            Particles(SpeedParticles, true);

        }
        else
        {
            Particles(SpeedParticles, false);
        }
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        // Takes input (WASD and converts into 1 and -1 depending upon input)
        Moveinput = context.ReadValue<Vector2>();   
    }
  
    private void Particles(ParticleSystem particle, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particle.emission;
        emissionModule.enabled = enabled;
    }

    private void WallHit()
    { 
        
        Particles(SpeedParticles, false);
        cooltime += Time.deltaTime;
        if (cooltime > 1.2f)
        {
            health--;
            Wallhit = false;
            cooltime = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Key>())
        {

            keys = collision.gameObject.GetComponent<Key>();
            KeyValue = keys.KeyValue;
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            Wallhit = true;

        }
        

    }

}
