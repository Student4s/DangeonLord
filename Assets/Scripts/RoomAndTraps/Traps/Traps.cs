using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int price;

    [SerializeField] private float hpDamage;
    [SerializeField] private float staminaDamage;
    
    [SerializeField] private Animator animations;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (col.collider.GetComponent<Hero>())
        {
            col.collider.GetComponent<Hero>().GetDamage(hpDamage,staminaDamage);
            animations.SetBool("Attack",true);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
