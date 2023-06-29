using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //Stats
    [SerializeField] private float attackDamage;
    [SerializeField] private float HP;
    [SerializeField] private float stamina;
    [SerializeField] private float mana;
    [SerializeField] private float perception;

    [SerializeField] private GameObject heroCamera;
    
    //Move
    private float speed;
    [SerializeField] private float walkSpeed;
    void Start()
    {
        CheckBox.ChestOpen1 += Stop;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        if(HP<=0)
            Death();
    }

    public bool PerceptionCheck(float needPerception)
    {
        if (perception >= needPerception)
            return true;
        else
            return false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void SetStartSpeed()
    {
        if (CheckBox.isChestSet)
        {
            speed = walkSpeed;
            heroCamera.SetActive(true);
        }
            
    }

    void Stop()
    {
        speed = 0;
    }

    private void OnDisable()
    {
        CheckBox.ChestOpen1 -= Stop;
    }
}
