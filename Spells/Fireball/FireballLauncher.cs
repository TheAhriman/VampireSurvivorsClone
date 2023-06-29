using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireballLauncher : BaseWeapon
{
    [SerializeField] private GameObject fireballPrefab;
    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();
        playerTransform = GetComponentInParent<PlayerMove>().transform;
    }
    protected override void Attack()
    {

        GameObject[] chosenTargets = new GameObject[0];

        for (int i = 0; i < WeaponStats.numberOfAttacks; i++)
        {
            GameObject closestEnemy = FindClosestEnemy(ref chosenTargets);

            if (closestEnemy != null)
            {
                Vector3 playerPosition = playerTransform.position;
                Vector3 direction = closestEnemy.transform.position - playerPosition;
                direction.Normalize();

                GameObject fireball = Instantiate(fireballPrefab, playerPosition, Quaternion.identity);
                Fireball fireballScript = fireball.GetComponent<Fireball>();
                Transform fireballTransform = fireball.GetComponent<Transform>();
                fireballTransform.localScale *= WeaponStats.size;
                fireballScript.damage = WeaponStats.damage;
                if (fireballScript != null)
                {
                    fireballScript.Launch(direction);
                }
            }
        }
    }

    private GameObject FindClosestEnemy(ref GameObject[] exceptions)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Except(exceptions).ToArray<GameObject>(); ;
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = playerTransform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(playerPosition, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }
        Array.Resize(ref exceptions, exceptions.Length + 1);
        exceptions[exceptions.Length - 1] = closestEnemy;
        return closestEnemy;
    }
}
