using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    public GameObject bala;
    private Rigidbody2D rb;
    Vector3 worldPosition;
    Vector3 shootDirection;



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
        worldPosition = worldPosition - transform.position;
        float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
        //float velocidad = Mathf.Sqrt((worldPosition.y * (2f * 9.8f)) / MathF.Pow(Mathf.Sin(rotZ), 2f));
        GameObject bullet = Instantiate(bala,transform.position, Quaternion.identity) as GameObject;
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(worldPosition.x * 2, worldPosition.y * 2);

        //Debug.Log(rotZ.ToString());
        //Debug.Log(worldPosition.ToString());



    }

   
}
