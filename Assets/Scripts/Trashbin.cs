using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour
{
 
    public GameManager gameManager;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.ResetGelas();
        if (collision.gameObject.CompareTag("Gelas"))
        {
            Destroy(collision.gameObject);
            gameManager.DeleteObjectsWithTag();
        }
    }  
}
