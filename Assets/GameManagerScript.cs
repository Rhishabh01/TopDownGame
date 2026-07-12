using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    
    public bool Completed;
    private float time;
    private int Finaltime;
    private bool HasLogged;
    [SerializeField] private GameObject PlayerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HasLogged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Completed == true && HasLogged == false)
        {
            Debug.Log("your final time " + Finaltime + "here ");
            HasLogged = true;
        }
        else 
        {
            
            time += Time.deltaTime;
            Finaltime = (int)time;
        }


    }
 
}
