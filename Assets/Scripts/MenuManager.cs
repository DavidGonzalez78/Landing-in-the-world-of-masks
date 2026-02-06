using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene("LevelDesign");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
