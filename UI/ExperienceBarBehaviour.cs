using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarBehaviour : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetExperience(float experience, float expToLvl)
    {
        slider.value = experience;
        slider.maxValue = expToLvl;
    }
}
