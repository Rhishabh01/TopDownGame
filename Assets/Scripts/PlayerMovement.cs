using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D playerrb;
    [SerializeField] private float MoveSpeed;
    private Vector2 Moveinput;
    private bool Wallhit;
    float speedX, speedY;
    private float time;
    private int Finaltime;
    private bool StartTime;
    private float cooltime;
    private bool Finished;
    private bool Completed;
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem SpeedParticles;
    public bool KeyCollected;
   
    void Start()
    {
        health = 380;
        SpeedParticles.Play();
        Application.targetFrameRate = 60;
        playerrb = GetComponent<Rigidbody2D>();
        Wallhit = false;
        StartTime = true;
        Completed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //Applies Force locally not for the world
        if(health > 0)
        {
            

            if (!Wallhit)
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
            else
            {
                WallHit();
                
            }
           

        }
        else
        {
            Particles(SpeedParticles, false);
            Debug.Log("Game Over");
        }
        if(StartTime == true)
        {
            time += Time.deltaTime;
            Debug.Log(time);
        }
        if(Finished == true && StartTime == false && Completed == false)
        {
            Finaltime = (int)time;
            Debug.Log("your final time " + Finaltime + "here ");
            Completed = true;
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
        MoveSpeed = 5;
        Particles(SpeedParticles, false);
        cooltime += Time.deltaTime;
        if (cooltime > 1.5f)
        {
            health--;
            Wallhit = false;
            cooltime = 0;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            Wallhit = true;
            
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        { 
            Finished = true;
            StartTime = false;
        }
        if (collision.gameObject.GetComponent<Laser>())
        {
            int strin = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(strin);
            Debug.Log("hit");
        }
        if (collision.gameObject.GetComponent<Key>())
        {
            KeyCollected = true;
            Debug.Log(KeyCollected);
        }

    }
}
