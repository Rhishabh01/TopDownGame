using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    
    public bool Completed;
    private float time;
    private int Finaltime;
    private bool HasLogged;
    private bool TimeFail;
    private PlayerMovement Player;
    private string TextString;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private TextMeshProUGUI DisplayTime;
    [SerializeField] private TextMeshProUGUI DisplayLifes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 120;

        Player = FindAnyObjectByType<PlayerMovement>();
        HasLogged = false;
        TimeFail = false;
        DisplayTime.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLifes.text = $"Health {Player.health.ToString()} ";

        if (Completed == true && HasLogged == false && TimeFail == false)
        {
            
            HasLogged = true;
            TextString = "Mission Complete " + "\n Time Taken " + Finaltime ; 
            GameOverText.text = TextString;
            GameOverText.gameObject.SetActive(true);
        }
        if(TimeFail == false && Completed == false)
        {
            DisplayTime.text = $"Time Taken {Finaltime.ToString()} ";
            time += Time.deltaTime;
            Finaltime = (int)time;
        }

        if(time > 15 && Completed == false)
        {
            TimeFail = true;
            Player.TimeFail = TimeFail;
            TextString = "Mission Failed";
            GameOverText.text = TextString;
            GameOverText.gameObject.SetActive(true);
        }

        if(Player.health <= 0)
        {
           
            TextString = "Mission Failed";
            GameOverText.text = TextString;
            GameOverText.gameObject.SetActive(true);
        }
    }
 
}
