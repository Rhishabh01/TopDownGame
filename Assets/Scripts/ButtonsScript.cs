using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject HideButton1;
    [SerializeField] GameObject HideButton2;
    [SerializeField] GameObject HideButton3;
    [SerializeField] GameObject BackButton;
    [SerializeField] GameObject LevelSelect;
    private int LevelToMove;
    private int HomeScreenIndex = 0;
    [SerializeField] private int LevelToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        int val = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(val);
    }

    public void StartGame()
    {
         SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        HideButton1.SetActive(false);
        HideButton2.SetActive(false);
        HideButton3.SetActive(false);
        BackButton.gameObject.SetActive(true);
    }
    public void Back()
    {
        HideButton1.SetActive(true);
        HideButton2.SetActive(true);
        HideButton3.SetActive(true);
        LevelSelect.SetActive(false);
        BackButton.gameObject.SetActive(false);
    }
    public void SelectLevel()
    {

        HideButton1.SetActive(false);
        HideButton2.SetActive(false);
        HideButton3.SetActive(false);
        LevelSelect.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }
    public void HomeScreen()
    {
        SceneManager.LoadScene(HomeScreenIndex);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void NextLevel()
    {
        LevelToMove = SceneManager.GetActiveScene().buildIndex;

        if (LevelToMove < 5)
        {
            
            SceneManager.LoadScene(LevelToMove + 1); 
            
        }
        else 
        {
            SceneManager.LoadScene(HomeScreenIndex);
        }
    }
}
