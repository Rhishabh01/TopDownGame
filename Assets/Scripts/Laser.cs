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

       
            Color c = LaserRender.color;
             c.a = Mathf.PingPong(1, 1f);
            LaserRender.color = c;
                
               
    }
   public void DisableLaser()
    {
        LaserBox.SetActive(false);
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
    


