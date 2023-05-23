using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    public GameObject[] bullets;


    private Rigidbody2D rb;
    Vector3 worldPosition;
    Vector3 shootDirection;
    [SerializeField] private int BulletCount;
    public GameObject canvasLose;
    public TMP_Text textoScoreWin;
    public TMP_Text textoScoreLose;
    public int i;
    [SerializeField] private int bulletSpeed;
    [SerializeField] public int score;
   

    private void Start()
    {
        canvasLose.SetActive(false);
    }


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
        if (bullets[i].gameObject.CompareTag("GreenBullet"))
        {
            Debug.Log("verde");
            bulletSpeed = 2;
        }
        if (bullets[i].gameObject.CompareTag("RedBullet"))
        {
            Debug.Log("rojo");
            bulletSpeed = 5;
        }
        if (bullets[i].gameObject.CompareTag("BlackBullet"))
        {
            Debug.Log("negro");
            bulletSpeed = 3;
        }
            
        
        
        worldPosition = worldPosition - transform.position;
        float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
        rb = bullets[i].GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(worldPosition.x * bulletSpeed, worldPosition.y * bulletSpeed );
        Debug.Log("numerodetorres" + i);

        i++;
        score = (BulletCount - i+1)* 2500;

        textoScoreWin.text = score.ToString();
        textoScoreLose.text = score.ToString();




        if (i == BulletCount)
        {
            StartCoroutine(WaitForLoose());
            

        }
    }

    IEnumerator WaitForLoose()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("GameOver");
        canvasLose.SetActive(true);
    }

}


   

   

