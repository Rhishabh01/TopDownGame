using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject HideButton1;
    [SerializeField] GameObject HideButton2;
    [SerializeField] GameObject HideButton3;
    [SerializeField] GameObject BackButton;
   
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
        BackButton.SetActive(true);
    }
    public void Back()
    {
        HideButton1.SetActive(true);
        HideButton2.SetActive(true);
        HideButton3.SetActive(true);
        BackButton.SetActive(true);
    }
    public void SelectLevel()
    {

        HideButton1.SetActive(false);
        HideButton2.SetActive(false);
        HideButton3.SetActive(false);
        BackButton.SetActive(true);
    }
}
