using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimeSpell : BaseWeapon
{

    protected override void Attack()
    {
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.GetComponent<Enemy>() != null)
            {
                obj.GetComponent<Enemy>().StopMovingEnemy();
                obj.GetComponent<Animator>().enabled = false;
            }
        }
        Invoke("UnPauseEnemies", 3);
    }

    private void UnPauseEnemies()
    {
        foreach(GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.GetComponent<Enemy>() != null)
            {
                obj.GetComponent<Enemy>().StartMovingEnemy();
                obj.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
