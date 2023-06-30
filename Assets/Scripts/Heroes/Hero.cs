using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //Stats
    [SerializeField] private float attackDamage;
    [SerializeField] private float exhaustedAttackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float currentTimeBetweenAttack;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject target;
    private Vector3 _heroPosition;
    
    [SerializeField] private float hp;
    [SerializeField] private float stamina;
    
    [SerializeField] private float perception;
    [SerializeField] private float currentTrapLvl;
    [SerializeField] private GameObject currentTrap;

    [SerializeField] private string status;
    
    [SerializeField] private GameObject heroCamera;
    
    //Move
    private float _speed;
    [SerializeField] private float walkSpeed;
    void Start()
    {
        CheckBox.ChestOpen1 += Stop;
        status = "Walk";
        _heroPosition = gameObject.transform.position;
    }
    void FixedUpdate()
    {
        switch (status)
        {
            case("Walk"):
                Walk();
                break;
            case("Perception Check"):
                PerceptionCheck();
                break;
            case("Fight"):
                Fight();
                break;
        }

        currentTimeBetweenAttack -= Time.fixedDeltaTime;
        if (stamina < 0)
        {
            attackDamage = exhaustedAttackDamage;
        }
    }

    public void Attack(GameObject enemy)
    {
        target = enemy;
        status = "Fight";
    }
    void Fight()
    {
        if (target == null)
            status = "Walk";
        
        if (Math.Abs(transform.position.x- target.transform.position.x)<=attackDistance)
        {
            if (currentTimeBetweenAttack <= 0)
            {
                target.GetComponent<BasedEnemy>().GetDamage(attackDamage);
                currentTimeBetweenAttack = attackSpeed;
            }
        }
        else
        {
            transform.position += new Vector3(_speed * Time.fixedDeltaTime, 0, 0);
            stamina -= Time.fixedDeltaTime;
        }
    }
    public void GetDamage(float damage)
    {
        hp -= damage;
        if(hp<=0)
            Death();
    }

    public void Trap(float needPerception, GameObject trap)
    {
        currentTrapLvl = needPerception;
        status = "Perception Check";
        currentTrap = trap;
    }

    void PerceptionCheckAccess()
    {
        currentTrapLvl = 0;
        Destroy(currentTrap.gameObject);
        status = "Walk";
    }
    
    public void PerceptionCheck()
    {
        if (perception >= currentTrapLvl)
        {
            Invoke("PerceptionCheckAccess", 1.0f);
        }
        else
            status = "Walk";
    }

    void Walk()
    {
        transform.position += new Vector3(_speed * Time.fixedDeltaTime, 0, 0);
        stamina -= Time.fixedDeltaTime;
    }

    public void SetStartSpeed()
    {
        if (CheckBox.isChestSet)
        {
            _speed = walkSpeed;
            heroCamera.SetActive(true);
            status = "Walk";
        }
    }
    void Stop()
    {
        _speed = 0;
    }
    
    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        CheckBox.ChestOpen1 -= Stop;
    }
}
