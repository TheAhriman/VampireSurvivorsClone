using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
