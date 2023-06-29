using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] private List<GameObject> dropObject;
    [SerializeField] [Range(0f,1f)] float spawnChance = 1f;

    private void OnDestroy()
    {
        if (Random.value < spawnChance)
        {
            Vector3 dropPosition = gameObject.transform.position;
            GameObject toDrop = dropObject[Random.Range(0,dropObject.Count)];
            GameObject drop = Instantiate(toDrop);
            drop.transform.position = dropPosition;
        }
    }
}
