using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    [SerializeField] private Animator animations;
    [SerializeField] private float speed;
    [SerializeField] private float hpDamage;
    [SerializeField] private float staminaDamage;

    private void Start()
    {
        animations.Play("WormProjectile");
    }

    private void FixedUpdate()
    {
        transform.Translate(-speed*Time.fixedDeltaTime,0,0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Hero>())
        {
            col.GetComponent<Hero>().GetDamage(hpDamage,staminaDamage);
            animations.Play("ProjectileExplosion");
            speed = 0;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
