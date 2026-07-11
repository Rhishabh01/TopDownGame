using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
   
    [SerializeField] public ParticleSystem laserparticles;
    [SerializeField] public BoxCollider2D boxCollider2D;
    [SerializeField] public int LaserVal;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
       
               
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
    


