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
    [SerializeField] private float TransitionSpeed = 5f;
    [SerializeField] public int LaserVal;
    [SerializeField] private Vector3 LaserSize;
    private PlayerMovement player;
    [SerializeField] private Color Color1;
    [SerializeField] private Color Color2;
    [SerializeField] private bool Collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collected = false;
        player = FindAnyObjectByType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
        

       if(player.KeyValue == LaserVal )
        {
            DisableLaser();
        }
        if(Collected == false)
        {

            float t = Mathf.PingPong(Time.time * 5f, 1f);
            Color ColorLaser = LaserRender.color;
            ColorLaser = Color.Lerp(Color2, Color1, t);
            LaserRender.color = ColorLaser;
        }
        
       
            
                
               
    }
 
   private void DisableLaser()
    {
        Color AlphaVal = LaserRender.color;
        float Transistion =+ Time.deltaTime * TransitionSpeed;
        AlphaVal.a = Mathf.Lerp(AlphaVal.a, 0, Transistion );
        LaserRender.color = AlphaVal;
        boxCollider2D.enabled = false;
        Collected = true;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            int strin = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(strin);
          
        }

      

    }

}
    


