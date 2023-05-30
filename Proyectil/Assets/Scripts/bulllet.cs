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
    [SerializeField] private float bulletSpeed;
    [SerializeField] public int score;

    public bool canShoot;
   // [SerializeField] public Camera cam;
   

    private void Start()
    {
        canvasLose.SetActive(false);
        canShoot = true;
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
        if (canShoot)
        {
            if (bullets[i].gameObject.CompareTag("GreenBullet"))
            {
          
                bulletSpeed = 3;
            }
            if (bullets[i].gameObject.CompareTag("RedBullet"))
            {
           
                bulletSpeed = 5;
            }
            if (bullets[i].gameObject.CompareTag("BlackBullet"))
            {
           
                bulletSpeed = 3;
            }
            if (bullets[i].gameObject.CompareTag("PurpleBullet")) 
            { 
          
                bulletSpeed = 7;
            }
            
        
        
            worldPosition = worldPosition - transform.position;
            float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
            rb = bullets[i].GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(worldPosition.x * bulletSpeed, worldPosition.y * bulletSpeed );
            /*while (bullets[i].gameObject != null)
            {
                cam.transform.Translate(new Vector3(bullets[i].transform.position.x
                ,bullets[i].transform.position.y ,0));
            }*/
            

            i++;
            score = (BulletCount - i + 1) * 2500 + 3000;

            textoScoreWin.text = score.ToString();
            textoScoreLose.text = score.ToString();
        }
        
        if (i == BulletCount)
        {
            StartCoroutine(WaitForLoose());
            

        }
    }

    IEnumerator WaitForLoose()
    {
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0;
        score = 0;
        canvasLose.SetActive(true);
        canShoot = false;
    }

}




   

   

