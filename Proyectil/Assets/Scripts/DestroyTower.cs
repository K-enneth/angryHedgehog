
using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    public GameObject[] towers;
    public int numeroDeTorres = 3;
    public int torresDerribadas=0;
    public GameObject canvasWin;
    public AudioSource splash;
    public AudioSource win;
    public bulllet bulllet;
    private void Start()
    {
        Time.timeScale = 1;
        towers = GameObject.FindGameObjectsWithTag("Tower");
        Debug.Log(towers);
        canvasWin.SetActive(false);
        

    }

    void Update()
    {

        CheckWin();

    }

    // Update is called once per frame

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            Debug.Log("torre derribada");
            torresDerribadas++;
            if (!splash.isPlaying)
            {
                splash.Play();
            }
            
        } 
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }

    public void CheckWin()
    {

        if (torresDerribadas == numeroDeTorres)
        {
            win.Play();
            canvasWin.SetActive(true); 
            Time.timeScale = 0;
           
           

        }
      
    }

    
}
