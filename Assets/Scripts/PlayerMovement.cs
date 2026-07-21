using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D playerrb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private SpriteRenderer DroneRender;
    [SerializeField] private Color Color1;
    [SerializeField] private Color Color2;
    private Vector2 Moveinput;
    public bool Wallhit;
    private float cooltime;
    public bool TimeFail;
    public bool Completed;
    private bool RemovedVelocity;
    public bool InputGiven;
    [SerializeField] public int health;
    [SerializeField] private ParticleSystem SpeedParticles;
    public int KeyValue;
    private Key keys;
    private Vector2 ForceRemoval;
    private bool HitisTrue;
    public int currkeyval;
    void Start()
    {
        cooltime = 0f;
        InputGiven = false;
        RemovedVelocity = false;
        health = 3;
        SpeedParticles.Play();
        playerrb = GetComponent<Rigidbody2D>();
        MoveSpeed = 12;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Applies Force locally not for the world
        if (health > 0 && Completed == false && TimeFail == false)
        {

            if (Wallhit)
            {
                WallHit();    
            }
            else
            {
                Movement();
            }
            
        }
        else
        {
            if (RemovedVelocity == false)
            {
            ForceRemoval = playerrb.linearVelocity ;
            playerrb.linearVelocity -= ForceRemoval;
      
            Particles(SpeedParticles, false);
            }
        }

        if (HitisTrue)
        {
            HitResponse();
        }
    
    }

    private void Movement()
    {
        playerrb.AddRelativeForce(Vector2.up * Moveinput * MoveSpeed, ForceMode2D.Force);


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
            InputGiven = true;
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
            if (health > 0)
            {
                health--;
            }
            Wallhit = false;
            cooltime = 0;
        }
    }
    
    private void HitResponse()
    {
      cooltime += Time.deltaTime;  
      Color colordrone = DroneRender.color;
      float t = Mathf.PingPong(Time.time * 5f , 1f);
      colordrone = Color.Lerp(Color2, Color1, t);
      DroneRender.color = colordrone;
        if(cooltime > 1f)
        {
            HitisTrue = false;
            DroneRender.color = Color1;
            cooltime = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Key>())
        {
           
            keys = collision.gameObject.GetComponent<Key>();
            KeyValue = keys.KeyValue;
        }
        if (collision.gameObject.GetComponent<DamageOrb>())
        {
            if (health > 0)
            {
                health--;
                HitisTrue = true;
            }


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
