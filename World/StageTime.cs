using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageTime : MonoBehaviour
{
    private float stageTime;
    private TimerUI timer;

    public float CurrentTime { get=>stageTime; }

    public TimerUI TimerUI
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        timer = FindObjectOfType<TimerUI>();
    }
    private void Update()
    {
        stageTime += Time.deltaTime;
        timer.UpdateTime(stageTime);
    }
}
