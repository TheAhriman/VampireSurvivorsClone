using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    public static MessageSystem instance;

    [SerializeField] GameObject damageMessage;

    List<TMPro.TextMeshPro> messagePool;

    private int maxMessagesAtOneTime = 10;
    private int count;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        messagePool = new List<TMPro.TextMeshPro>();

        for (int i = 0; i < maxMessagesAtOneTime; i++)
        {
            Populate();
        }
    }
    private void Populate()
    {
        GameObject message = Instantiate(damageMessage,transform);
        messagePool.Add(message.GetComponent<TMPro.TextMeshPro>());
        message.SetActive(false);
    }
    public void PostMessage(string text, Vector3 worldPosition)
    {
        messagePool[count].gameObject.SetActive(true);
        messagePool[count].transform.position = worldPosition;
        messagePool[count].text = text;
        count++;

        if (count >= maxMessagesAtOneTime)
        {
            count = 0;
        }
    }
}
