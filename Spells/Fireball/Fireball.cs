using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 launchDirection;
    private Rigidbody2D rgdbd2d;
    private Vector3 spawnPosition;
    public float damage;
    [SerializeField] private FireballLauncher fireballLauncher;


    [SerializeField] private float maxDistance = 10f;
    [SerializeField] float speed = 10f;

    public FireballLauncher FireballLauncher
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector3 direction)
    {
        spawnPosition = transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        launchDirection = direction;
    }
    private void FixedUpdate()
    {
        rgdbd2d.velocity = launchDirection * speed;
        
        float distance = Vector3.Distance(transform.position,spawnPosition);
        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
