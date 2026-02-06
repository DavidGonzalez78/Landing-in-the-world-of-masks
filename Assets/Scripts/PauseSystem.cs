
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSystem : MonoBehaviour
{
    public GameObject PausePanel;
    private PlayerInput playerInput;
    private bool isPaused;

    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
    }
    private void Update()
    {
        if (playerInput.actions["Pause"].WasPressedThisFrame())
        {
            OnPause();
        }
    }
    // Update is called once per frame
    public void OnPause()
    {
            if (isPaused)
            {
                ClosePannel();
            }
            else
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        
    }
    public void ClosePannel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
