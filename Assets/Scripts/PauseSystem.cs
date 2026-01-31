
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {
        OpenSettings();
    }
    public void OpenSettings()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ClosePannel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
