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
    public GameObject canvasWin;
    public TMP_Text textoScoreWin;
    public TMP_Text textoScoreLose;
    public int i;
    [SerializeField] private int bulletSpeed;
    [SerializeField] public int score;
    [SerializeField] public AudioSource sad;
    [SerializeField] public AudioSource gun;
   

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
            gun.Play();
            Disparo();
        }
    }
    


    void Disparo()
    
    {
        if (bullets[i].gameObject.CompareTag("GreenBullet"))
        {
            bulletSpeed = 2;
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
        i++;

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

}
