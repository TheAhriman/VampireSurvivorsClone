using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void Update()
    {
        GetComponent<AudioSource>().volume = slider.value;
    }
}
