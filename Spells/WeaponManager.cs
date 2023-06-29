using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContatiner;

    [SerializeField] WeaponData startingWeapon;

    private List<BaseWeapon> weapons;

    private void Start()
    {
        weapons = new List<BaseWeapon>();
        AddWeapon(startingWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.weaponPrefab,weaponObjectsContatiner);

        BaseWeapon newWeapon = weaponGameObject.GetComponent<BaseWeapon>();

        newWeapon.SetData(weaponData);
        weapons.Add(newWeapon);

        LevelManager levelManager = GetComponent<LevelManager>();
        if (levelManager != null )
        {
            levelManager.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.weaponUpgrades);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        BaseWeapon weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
