using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool AnimCompleted;
    public bool Completed;
    private bool DisplayDone;
    private PlayerMovement player;
    private GameManagerScript GManager;
   [SerializeField] private float TransitionSpeed;
    [SerializeField] private ParticleSystem ExplosionParticles;
    private Quaternion rotate = Quaternion.Euler(0,0,-180f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Completed = false;
        GManager = FindAnyObjectByType<GameManagerScript>();
        player = FindAnyObjectByType<PlayerMovement>();
        player.Completed = Completed;

    }

    // Update is called once per frame
    void Update()
    {
        if(Completed == true)
        {
            Vector3 LandingPadpos = gameObject.transform.position;

            player.transform.localPosition = Vector3.Lerp(player.transform.position, LandingPadpos, Time.deltaTime * TransitionSpeed);
            player.transform.rotation = Quaternion.Lerp(player.transform.localRotation, rotate, Time.deltaTime * TransitionSpeed);
            if(LandingPadpos == player.transform.localPosition)
            {
                AnimCompleted = true;
            }
        }
    }
    private void FinalTimeDisplay()
    {
        
        Completed = true;
        player.Completed = Completed;
        GManager.Completed = Completed;
        ExplosionParticles.Play();
        DisplayDone = true;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            if(!DisplayDone)
            {
            FinalTimeDisplay();
            }
            
        }
    }

}
