using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //Stats
    [SerializeField] private float attackDamage;
    [SerializeField] private float exhaustedAttackDamage;
    public float attackSpeed;
    [SerializeField] private float currentTimeBetweenAttack;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject currrentTarget;
    [SerializeField] private List<GameObject> targets;
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
    
    public delegate void Perception(string text, Transform position);
    public static event Perception Accses;
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
            attackDamage = exhaustedAttackDamage;
    }

    public void Attack(GameObject enemy)
    {
        targets.Add(enemy);
        TargetUpdate();
        status = "Fight";
    }

    public void TargetUpdate()
    {
        for (int i = 0; i <= targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);  
            }
            else
            {
                currrentTarget = targets[i];
                status = "Fight";
                break;
            }
        }
        
    }
    void Fight()
    {
        if (currrentTarget == null)
            TargetUpdate();

        if (currrentTarget == null)
                status = "Walk";

        if (Math.Abs(transform.position.x- currrentTarget.transform.position.x)<=attackDistance)
        {
            if (currentTimeBetweenAttack <= 0)
            {
                currrentTarget.GetComponent<BasedEnemy>().GetDamage(attackDamage);
                currentTimeBetweenAttack = attackSpeed;
            }
        }
        else
        {
            transform.position += new Vector3(_speed * Time.fixedDeltaTime, 0, 0);
            stamina -= Time.fixedDeltaTime;
        }
    }
    public void GetDamage(float hpDamage, float staminaDamage)
    {
        hp -= hpDamage;
        stamina -= staminaDamage;
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
        Accses("Perception Check Access", gameObject.transform);
        currentTrapLvl = 0;
        Destroy(currentTrap.gameObject);
        status = "Walk";
        
    }
    
    public void PerceptionCheck()
    {
        if (perception >= currentTrapLvl)
        {
            //Invoke("PerceptionCheckAccess", 1.0f);
            PerceptionCheckAccess();
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
    
    void Death()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        CheckBox.ChestOpen1 -= Stop;
    }
}
