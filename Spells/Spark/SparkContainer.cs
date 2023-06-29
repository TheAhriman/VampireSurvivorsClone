using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkContainer : BaseWeapon
{
    [SerializeField] GameObject spark;
    List<GameObject> sparksOnMap;

    protected override void Start()
    {
        base.Start();
        sparksOnMap = new List<GameObject>();
        GameObject newSpark = Instantiate(spark, this.transform);
        newSpark.transform.localPosition = new Vector3(0f, 2f, 0f);
        sparksOnMap.Add(newSpark);
    }
    protected override void Attack()
    {
        transform.Rotate(new Vector3(0f, 0f, 1));
    }
    internal override void Upgrade(UpgradeData upgradeData)
    {
        base.Upgrade(upgradeData);
        if (upgradeData.upgradeWeaponStats.numberOfAttacks != 0 ) 
        {
            GameObject newSpark = Instantiate(spark, this.transform);
            sparksOnMap.Add(newSpark);
            int sparksCount = sparksOnMap.Count;
            switch (sparksCount)
            {
                case 2:
                    newSpark.transform.localPosition = new Vector3(0f, -2f, 0f);
                    break;
                case 3:
                    sparksOnMap[1].transform.localPosition = new Vector3(-2f, -1f, 0f);
                    sparksOnMap[2].transform.localPosition = new Vector3(2f, -1f, 0f);
                    break;
                case 4:
                    sparksOnMap[1].transform.localPosition = new Vector3(0f, -2f, 0f);
                    sparksOnMap[2].transform.localPosition = new Vector3(-2f, 0f, 0f);
                    sparksOnMap[3].transform.localPosition = new Vector3(2f, 0f, 0f);
                    break;
                case 5:
                    sparksOnMap[1].transform.localPosition = new Vector3(-1f, -2f, 0f);
                    sparksOnMap[2].transform.localPosition = new Vector3(1f, -2f, 0f);
                    sparksOnMap[3].transform.localPosition = new Vector3(-2f, 0f, 0f);
                    sparksOnMap[4].transform.localPosition = new Vector3(2f, 0f, 0f);
                    break;
                case 6:
                    sparksOnMap[0].transform.localPosition = new Vector3(1f, 2f, 0f);
                    sparksOnMap[5].transform.localPosition = new Vector3(-1f, 2f, 0f);
                    break;
            }
        }
    }
}
