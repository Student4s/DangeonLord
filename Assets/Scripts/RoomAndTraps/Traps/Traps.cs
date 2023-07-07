using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int price;

    [SerializeField] private float hpDamage;
    [SerializeField] private float staminaDamage;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Hero>())
        {
            col.collider.GetComponent<Hero>().GetDamage(hpDamage,staminaDamage);
            Destroy(gameObject);
        }
            
    }
}
