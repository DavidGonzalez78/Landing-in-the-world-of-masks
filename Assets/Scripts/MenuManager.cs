using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void CambioEscena()
    {
        SceneManager.LoadScene("LevelDesign");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
