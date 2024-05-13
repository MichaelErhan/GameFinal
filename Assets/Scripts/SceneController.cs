using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OpenMainScene()
    {
        SceneManager.LoadScene(1); 
    }

    public void OpenGameScene()
    {
        SceneManager.LoadScene(0);
    }
} 





