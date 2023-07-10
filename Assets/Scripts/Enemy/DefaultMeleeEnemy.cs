using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMeleeEnemy : BasedEnemy
{
    [SerializeField] private Animator animations;

    private void Start()
    {
        animations.Play("IDLE");
    }

    void FixedUpdate()
    {
        currentTimeBetweenAttack -= Time.fixedDeltaTime;
        if (target!=null)
        {
            if (Math.Abs(transform.position.x - target.transform.position.x) > attackDistance)
                MoveToTarget();
            else
                Attack();
        }
    }

    void Attack()
    {
        if (currentTimeBetweenAttack <= 0)
        {
            animations.SetBool("Attack",true);
            animations.SetBool("Walk",false);
            target.GetComponent<Hero>().GetDamage(attackHpDamage,attackStaminaDamage);
            currentTimeBetweenAttack = attackSpeed;
        }
        else
            animations.SetBool("Attack",false); 
    }

    void MoveToTarget()
    {
        transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0, 0);
        animations.SetBool("Walk",true);
    }

    public override void GetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
            Death();
    }

    public override void Death()
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
