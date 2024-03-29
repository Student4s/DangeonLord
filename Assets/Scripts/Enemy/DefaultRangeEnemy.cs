using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRangeEnemy : BasedEnemy
{
    [SerializeField] private Animator animations;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;
    
    private void Start()
    {
        animations.Play("IDLE");
        animations.SetBool("Death",false);
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
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);
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
        animations.SetBool("GetHit",true);
        if (hp <= 0)
        {
            currentTimeBetweenAttack = 10;
            animations.SetTrigger("Death");
            animations.SetBool("Attack",false); 
            animations.SetBool("Walk",false);
        }
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

    private void LateUpdate()
    {
        animations.SetBool("GetHit",false);
    }
}
