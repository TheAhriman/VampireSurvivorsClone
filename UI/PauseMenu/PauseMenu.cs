using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private PauseManager pauseManager;

    public PauseManager PauseManager
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeInHierarchy == false) { OpenMenu(); } else { CloseMenu(); }
        }
    }

    private void OpenMenu()
    {
        pausePanel.SetActive(true);
        pauseManager.PauseGame();
    }
    public void CloseMenu()
    {
        pausePanel.SetActive(false);
        pauseManager.UnPauseGame();
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
