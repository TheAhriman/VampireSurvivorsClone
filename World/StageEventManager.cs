using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;

    public StageTime StageTime
    {
        get => default;
        set
        {
        }
    }

    public StageData StageData
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) return;

        if (stageTime.CurrentTime > stageData.stageEvents[eventIndexer].time)
        {
            for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
            {
                enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
            }
            eventIndexer++;
        }
    }
}
    