
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private int SceneTo;
    
    // Start is called before the first frame update
    public void SelectLevel()
    {
        SceneManager.LoadScene(SceneTo);
    }

    
}
