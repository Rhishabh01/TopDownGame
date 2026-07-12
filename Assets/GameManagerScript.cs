using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    
    public bool Completed;
    private float time;
    private int Finaltime;
    private bool HasLogged;
    private bool TimeFail;
    private PlayerMovement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        HasLogged = false;
        TimeFail = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Completed == true && HasLogged == false && TimeFail == false)
        {
            Debug.Log("your final time " + Finaltime + "here ");
            HasLogged = true;
        }
        else 
        {
            
            time += Time.deltaTime;
            Finaltime = (int)time;
        }

        if(time > 15)
        {
            TimeFail = true;
            player.TimeFail = TimeFail;
            Debug.Log("Time Failed");
        }

        if(player.Completed == true)
        {
            // we get the next scene 
        }
    }
 
}
