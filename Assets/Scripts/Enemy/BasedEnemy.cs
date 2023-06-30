using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    
    [SerializeField] private float hp;
    
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float currentTimeBetweenAttack;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject target;
    
 

    void FixedUpdate()
    {
        currentTimeBetweenAttack -= Time.fixedDeltaTime;
        
        if (target!=null)
        {
            
            //Debug.Log(Math.Abs(transform.position.x-target.transform.position.x));
            if (Math.Abs(transform.position.x-target.transform.position.x) > attackDistance)
            {
                transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0); 
            }
            else
            {
                if (currentTimeBetweenAttack <= 0)
                {
                    target.GetComponent<Hero>().GetDamage(attackDamage);
                    currentTimeBetweenAttack = attackSpeed;
                }
            }
        }
    }
    
    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
            Death();
    }

    void Death()
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
}
