using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    public float damage;
    public void DisableWhip()
    {
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<IDamageable>() != null)
        {
            collider.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
