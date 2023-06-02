using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    public GameObject[] bullets;

    // BULLET PROPERTIES
    private Rigidbody2D rb;
    Vector3 worldPosition;
    Vector3 shootDirection;
    [SerializeField] private int BulletCount;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool isFar = false;
    
    //CANVAS 
    public GameObject canvasLose;
    public GameObject canvasWin;
    public TMP_Text textoScoreWin;
    public TMP_Text textoScoreLose;
    [SerializeField] public float score;
    
    //COUNTER
    public int i;
    public int follow;
    public int elseFollow;
    [SerializeField] private bool readyToShoot = true;
    
    //CAMERA
    [SerializeField] private Camera cam;
    [SerializeField] private Camera mainCam;



    // AUDIO
    [SerializeField] public AudioSource sad;
    [SerializeField] public AudioSource gun;
   

    private void Start()
    {
        canvasLose.SetActive(false);
        i = -1;
    }


    void Update()
    {
       
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.0f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            i++;
            gun.Play();
            Disparo();
           
        }
    }

    private void FixedUpdate()
    {
        
        
            cam.transform.position = new Vector3(bullets[i].transform.position.x , 
                bullets[i].transform.position.y , -10);
       
        
        
    }


    void Disparo()
    
    {
        
        if (bullets[i].gameObject.CompareTag("GreenBullet"))
        {
            bulletSpeed = 2;
            if (isFar)
            {
                bulletSpeed = 1.2f;
            }
            
        }
        if (bullets[i].gameObject.CompareTag("RedBullet"))
        {
            bulletSpeed = 5;
            if (isFar)
            {
                bulletSpeed = 2f;
            }
        }
        if (bullets[i].gameObject.CompareTag("BlackBullet"))
        {
            bulletSpeed = 3;
            if (isFar)
            {
                bulletSpeed = 1f;
            }
        }
        if (bullets[i].gameObject.CompareTag("PurpleBullet"))
        {
            bulletSpeed = 7;
            if (isFar)
            {
                bulletSpeed = 3f;
            }
        }

        
        
        worldPosition = worldPosition - transform.position;
        float rotZ = Mathf.Atan2(worldPosition.y, worldPosition.x) * Mathf.Rad2Deg;
        rb = bullets[i].GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(worldPosition.x * bulletSpeed, worldPosition.y * bulletSpeed );
        
       

        if( canvasWin.activeInHierarchy== false)
        {
            score = (BulletCount - i + 1) * 2500 + 3000;
            textoScoreWin.text = score.ToString();
            textoScoreLose.text = score.ToString();
            gun.volume = 0;
        }
        if (i == BulletCount)
        {
            StartCoroutine(WaitForLoose());
        }
       
    }

    IEnumerator WaitForLoose()
    {
        yield return new WaitForSeconds(5f);
        
        if (canvasWin.activeInHierarchy == false)
        {
            canvasLose.SetActive(true);
            Time.timeScale = 0;
            if (!sad.isPlaying)
            {
                sad.Play();
            }
        }
        


    }

    IEnumerator Died()
    {
        yield return new WaitForSeconds(3f);
        cam.transform.position = new Vector3(0, 0, -10);
        readyToShoot = true;
    }

}
