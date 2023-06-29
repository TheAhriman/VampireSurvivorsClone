using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void SetLevelText(int level)
    {
        levelText.text = "LEVEL: " + level.ToString();
    }
}
