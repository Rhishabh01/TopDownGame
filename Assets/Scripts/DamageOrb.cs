using UnityEngine;

public class DamageOrb : MonoBehaviour
{
    private float UpdatePos;
    [SerializeField] private float StartPos;
    [SerializeField] private float EndPos;
    [SerializeField] private bool XaxisMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(XaxisMovement == false)
        {
            float t = (Mathf.Sin(Time.time) + 1) / 2;
            // float t = Mathf.PingPong(Time.time * 0.2f, 1);

            UpdatePos = Mathf.Lerp(StartPos, EndPos, t); // Y is updated 

            gameObject.transform.position = new Vector2(gameObject.transform.position.x, UpdatePos);
        }
        

        if(XaxisMovement == true)
        {
            float st = (Mathf.Sin(Time.time) + 1) / 2;
            // float t = Mathf.PingPong(Time.time * 0.2f, 1);

            UpdatePos = Mathf.Lerp(StartPos, EndPos, st); // Y is updated 

            gameObject.transform.position = new Vector2(UpdatePos, gameObject.transform.position.y);
        }

    }


}
