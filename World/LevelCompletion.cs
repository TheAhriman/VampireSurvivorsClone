using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] private float timeToCompleteLevel;

    private StageTime stageTime;
    private PauseManager pauseManager;

    [SerializeField] GameObject levelCompletePanel;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
    }
    private void Update()
    {
        if (stageTime.CurrentTime > timeToCompleteLevel)
        {
            levelCompletePanel.SetActive(true);
            pauseManager.PauseGame();
        }
    }
}
