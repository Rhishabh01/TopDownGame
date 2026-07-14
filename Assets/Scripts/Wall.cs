using UnityEngine;

public class Wall : MonoBehaviour
{
    
    public bool Completed;
    private PlayerMovement player;
    private GameManagerScript GManager;
    private float TransitionSpeed = 1.3f;
    
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

            player.transform.position = Vector3.Lerp(player.transform.position, LandingPadpos, Time.deltaTime * TransitionSpeed);
            player.transform.rotation = Quaternion.Lerp(player.transform.localRotation, rotate, Time.deltaTime * TransitionSpeed);

        }
    }
    private void FinalTimeDisplay()
    {
        
        Completed = true;
        player.Completed = Completed;
        GManager.Completed = Completed;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("reached");
            FinalTimeDisplay();
            
        }
    }

}
