using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    public GameObject[] towers;
    // Start is called before the first frame update

    private void Start()
    {
        
        towers = GameObject.FindGameObjectsWithTag("Tower");
        Debug.Log(towers);
        
    }

    void Update()
    {
        
        CheckWin();
        
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision2d)
    {
        Destroy(collision2d.gameObject);
        
    }

    private void CheckWin()
    {

        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i] != isActiveAndEnabled)
            {
                Debug.Log("Ganaste");
            }
        }
        
        
    }

    
}
