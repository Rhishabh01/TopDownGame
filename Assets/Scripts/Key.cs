using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] public int KeyValue;
    [SerializeField] private float OriginalPos ;
    [SerializeField] private float NewPos;
    [SerializeField] private bool KeyCollected = false;
    private float UpdatePos;
    private float UpdatePos2;
    private float Pingpongval;
    private bool AnimDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OriginalPos = gameObject.transform.position.y;
        AnimDone = false;
    }

    // Update is called once per frame
    void Update()
    {


        // take orginal pos where the key was located  and move to new postion of y (X is not touched)
        // Y is assigned

         float t = (Mathf.Sin(Time.time) +1 )/2 ;
        // float t = Mathf.PingPong(Time.time * 0.2f, 1);
            
            UpdatePos = Mathf.Lerp(OriginalPos, NewPos, t); // Y is updated 

        gameObject.transform.position = new Vector2(gameObject.transform.position.x, UpdatePos );











    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        { 
            Destroy(gameObject);
            
                
        }

        
        
    }
}
