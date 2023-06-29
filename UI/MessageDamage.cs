using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDamage : MonoBehaviour
{
    [SerializeField] float timeToLive = 2f;

    private void OnEnable()
    {
        Invoke("DisableMessage",timeToLive);
    }
    private void DisableMessage()
    {
        gameObject.SetActive(false);
    }
}
