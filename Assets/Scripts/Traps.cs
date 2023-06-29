using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int price;

    [SerializeField] private float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Hero>())
        {
            col.collider.GetComponent<Hero>().GetDamage(damage);
            Destroy(gameObject);
        }
            
    }
}
