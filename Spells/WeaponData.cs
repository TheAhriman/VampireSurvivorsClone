using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public float size;
    public int numberOfAttacks;
    public WeaponStats(int _damage, float _timeToAttack, float _size, int numberOfAttacks)
    {
        damage = _damage;
        timeToAttack = _timeToAttack;
        size = _size;
        this.numberOfAttacks = numberOfAttacks;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.size += weaponUpgradeStats.size;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
    }
}
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponPrefab;
    public List<UpgradeData> weaponUpgrades;

    public WeaponStats WeaponStats
    {
        get => default;
        set
        {
        }
    }
}
