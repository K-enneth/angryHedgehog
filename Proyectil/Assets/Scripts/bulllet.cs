using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    public GameObject[] bullets;
    
    
    private Rigidbody2D rb;
    Vector3 worldPosition;
    Vector3 shootDirection;
    [SerializeField] private int BulletCount = 2;
    public GameObject canvasWin;
    



    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            Disparo();

        }
    }

   

   void Disparo()
   {
       {

           if (BulletCount == 3)
           {
               worldPosition = worldPosition - transform.position;
               float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
               rb = bullets[0].GetComponent<Rigidbody2D>();
               rb.velocity = new Vector2(worldPosition.x * 2, worldPosition.y * 2);
               BulletCount = BulletCount - 1;
               Debug.Log(BulletCount);
             
           }
           else if (BulletCount == 2)
           {
               worldPosition = worldPosition - transform.position;
               float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
               rb = bullets[1].GetComponent<Rigidbody2D>();
               rb.velocity = new Vector2(worldPosition.x * 2, worldPosition.y * 2);
               BulletCount = BulletCount - 1;
               Debug.Log(BulletCount);
               
               
               
           }
           else if (BulletCount == 1)
           {
               worldPosition = worldPosition - transform.position;
               float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
               rb = bullets[2].GetComponent<Rigidbody2D>();
               rb.velocity = new Vector2(worldPosition.x * 5, worldPosition.y * 5);
               BulletCount = BulletCount - 1;
               Debug.Log(BulletCount);
               
           }



           if ((BulletCount == 0))
           {
               Debug.Log("GameOver");
           }
       }



   }

   
}
