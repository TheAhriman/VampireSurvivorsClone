using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    [SerializeField] GameObject explosion;
    Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
    
    protected override void Die()
    {
        StartCoroutine("EnableExplosion");
    }

    private IEnumerator EnableExplosion()
    {
        StopMovingEnemy();
        animator.Play("Bat_Death");
        explosion.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
