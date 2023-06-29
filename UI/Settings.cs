using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] Toggle screenToggle;
    [SerializeField] TMP_Dropdown screenResolution;
    public void ChangeResolution()
    {
        switch (screenResolution.value)
        {
            case 0: Screen.SetResolution(1920, 1080, screenToggle.isOn); break;
            case 1: Screen.SetResolution(1280, 720, screenToggle.isOn); break;
            case 2: Screen.SetResolution(854, 480, screenToggle.isOn); break;
            case 3: Screen.SetResolution(640, 360, screenToggle.isOn); break;
        }
    }
}
