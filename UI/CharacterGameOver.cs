using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
