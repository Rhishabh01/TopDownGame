using UnityEngine;

public class Wall : MonoBehaviour
{
    
    public bool Completed;
    private PlayerMovement player;
    private GameManagerScript GManager;
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
