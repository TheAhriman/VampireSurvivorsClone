using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderLauncher : BaseWeapon
{
    [SerializeField] GameObject thunderPrefab;
    [SerializeField] float viewRadius = 5f;
    [SerializeField] LayerMask enemyLayer;
    private Transform player;

    protected override void Start()
    {
        base.Start();
        player = GetComponentInParent<Transform>();
    }
    protected override void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(player.position, viewRadius, enemyLayer);

        if (enemies.Length > 0)
        {
            Collider2D randomEnemy = enemies[Random.Range(0, enemies.Length)];

            Vector3 spawnPosition = randomEnemy.transform.position + new Vector3(0f, 1f, 0f);
            Instantiate(thunderPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
