using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{

    [SerializeField] private GameObject LaserBox;
    [SerializeField] public BoxCollider2D boxCollider2D;
    [SerializeField] private SpriteRenderer LaserRender;
    private float TransitionSpeed = 2f;
    [SerializeField] public int LaserVal;
    private PlayerMovement player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(player.KeyValue == LaserVal)
        {
            DisableLaser();
        }

       
            
                
               
    }
   public void DisableLaser()
    {
        Color c = LaserRender.color;
        c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * TransitionSpeed);
        LaserRender.color = c;
        boxCollider2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            int strin = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(strin);
            Debug.Log("hit");
        }

      

    }

}
    


