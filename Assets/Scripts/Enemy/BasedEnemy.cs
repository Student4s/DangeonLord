using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedEnemy : MonoBehaviour
{
    [SerializeField] public int price;
    [SerializeField]private bool canSpawn = true;
    
    
    [SerializeField] protected float speed;
    [SerializeField] protected float hp;
    
    [SerializeField] protected float attackHpDamage;
    [SerializeField] protected float attackStaminaDamage;
    
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float currentTimeBetweenAttack;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected GameObject target;
    
 

    void FixedUpdate()
    {
        currentTimeBetweenAttack -= Time.fixedDeltaTime;
        
        if (target!=null)
        {
            if (Math.Abs(transform.position.x-target.transform.position.x) > attackDistance)
            {
                transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0); 
            }
            else
            {
                if (currentTimeBetweenAttack <= 0)
                {
                    target.GetComponent<Hero>().GetDamage(attackHpDamage,attackStaminaDamage);
                    currentTimeBetweenAttack = attackSpeed;
                }
            }
        }
    }
    
     virtual public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
            Death();
    }

     virtual public void Death()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Hero>())
        {
            target = col.gameObject;
            col.GetComponent<Hero>().Attack(gameObject);
        }
    }
    
    public bool IsCanSpawn()
    {
        return canSpawn;
    }

    public void ChangeIsCanSpawn(bool state)
    {
        canSpawn = state;
    }

}
