using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

   // private bool AnimCompleted;

    public bool Completed;
    private float time;
    private int Finaltime;
    private bool TimeFail;
    private PlayerMovement Player;
    private string TextString;
    private bool InputGiven;
    [SerializeField] private Wall LandingPad;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private TextMeshProUGUI DisplayTime;
    [SerializeField] private TextMeshProUGUI DisplayLifes;
    [SerializeField] private int FPS;
    [SerializeField] private GameObject CompletedLevelUI;
    [SerializeField] private GameObject NotCompletedLevelUI;
    [SerializeField] private GameObject HomeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = FPS;
        Player = FindAnyObjectByType<PlayerMovement>();
        TimeFail = false;
        DisplayTime.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(false);
        CompletedLevelUI.gameObject.SetActive(false);
        HomeButton.gameObject.SetActive(false);
        NotCompletedLevelUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLifes.text = $"Life Left {Player.health.ToString()} ";

        if (Completed == true  && TimeFail == false)
        {
            
            
            if(LandingPad.AnimCompleted == true)
            {
                TextString = "Mission Complete " + "\n Time Taken " + Finaltime;
                GameOverText.text = TextString;
                GameOverText.gameObject.SetActive(true);
                HomeButton.gameObject.SetActive(true);

            }
            
        }
        if(TimeFail == false && Completed == false && Player.InputGiven == true)
        {
            
                DisplayTime.text = $"Time Taken {Finaltime.ToString()} ";
                time += Time.deltaTime;
                Finaltime = (int)time;
                
            
        }

        if(time >= 15 && Completed == false)
        {
            TimeFail = true;
            Player.TimeFail = TimeFail;
            TextString = "Mission Failed";
            GameOverText.text = TextString;
            HomeButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
            NotCompletedLevelUI.gameObject.SetActive(true);
        }

        if(Completed == true && LandingPad.AnimCompleted == true)
        {
            CompletedLevelUI.SetActive(true);
            HomeButton.gameObject.SetActive(true);
        }

        if(Player.health <= 0)
        {
           
            TextString = "Mission Failed";
            GameOverText.text = TextString;
            HomeButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
            NotCompletedLevelUI.gameObject.SetActive(true);
        }
        
        

    }
 
}
