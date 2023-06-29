using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public WeaponData weaponData;

    private WeaponStats weaponStats;
    private float timer;
    public WeaponStats WeaponStats { get => weaponStats; }

    public WeaponStats WeaponStats1
    {
        get => default;
        set
        {
        }
    }

    public WeaponData WeaponData
    {
        get => default;
        set
        {
        }
    }

    protected virtual void Start()
    {
        SetData(weaponData);
    }
    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }
    public virtual void SetData(WeaponData _weaponData)
    {
        weaponData = _weaponData;
        weaponStats = new WeaponStats(weaponData.stats.damage, weaponData.stats.timeToAttack,weaponData.stats.size,weaponData.stats.numberOfAttacks);
    }
    protected abstract void Attack();

    public void DealDamage(GameObject damageableObject)
    {
        damageableObject.GetComponent<IDamageable>().TakeDamage(weaponStats.damage);
    }

    internal virtual void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.upgradeWeaponStats);
    }
}
