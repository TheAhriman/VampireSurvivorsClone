using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Vector3 offset;
    public void SetHealth(float currentHp, float maxHp)
    {
        slider.gameObject.SetActive(currentHp < maxHp) ;
        slider.value = currentHp;
        slider.maxValue = maxHp;
        slider.fillRect.GetComponentInChildren<Image>().color = Color32.Lerp(new Color32(255,0,0,255),new Color32(0,255,0,255),slider.normalizedValue);
    }
    private void Update() 
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
}
