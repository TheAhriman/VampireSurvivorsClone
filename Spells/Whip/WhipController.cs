using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipController : BaseWeapon
{
    private PlayerMove playerMove;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    public PlayerMove PlayerMove
    {
        get => default;
        set
        {
        }
    }

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for (int i = 0; i < WeaponStats.numberOfAttacks; i++)
        {
            Vector3 newSize = new Vector3(WeaponStats.size, WeaponStats.size, WeaponStats.size);
            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhipObject.SetActive(true);
                rightWhipObject.GetComponent<Transform>().localScale = newSize;
                rightWhipObject.GetComponent<Whip>().damage = WeaponStats.damage;
            }
            else
            {
                leftWhipObject.SetActive(true);
                leftWhipObject.GetComponent<Transform>().localScale = newSize;
                leftWhipObject.GetComponent<Whip>().damage = WeaponStats.damage;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
