using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
     private PlayerMovement Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.KeyCollected == true)
        {
            gameObject.SetActive(false);
        }

    }
}
