using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpawnZoneEnemy : MonoBehaviour
{
     [SerializeField]private int enemyNear=0;
     [SerializeField]private int maxEnemyNear;
     [SerializeField] private BasedEnemy thisEnemy;

     public List<GameObject> inTriggerEnemy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BasedEnemy>())
        {
            if (!inTriggerEnemy.Contains(col.gameObject))
            {
                inTriggerEnemy.Add(col.gameObject);
                enemyNear = inTriggerEnemy.Count;
            }
            if(maxEnemyNear<enemyNear) 
                thisEnemy.ChangeIsCanSpawn(false);
            if(maxEnemyNear>enemyNear) 
                thisEnemy.ChangeIsCanSpawn(true);
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<BasedEnemy>())
        {
            if (inTriggerEnemy.Contains(col.gameObject))
            {
                inTriggerEnemy.Remove(col.gameObject);
                enemyNear = inTriggerEnemy.Count;
            }
            if(maxEnemyNear<enemyNear) 
                thisEnemy.ChangeIsCanSpawn(false);
            if(maxEnemyNear>enemyNear) 
                thisEnemy.ChangeIsCanSpawn(true);
        }
    }
}
