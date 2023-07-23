using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeble : Trait
{
    [SerializeField] private float hpDebaff;
    [SerializeField] private float damageDebaff;
    public override void Use(GameObject hero)
    {
        hero.GetComponent<Hero>().hp -= hpDebaff;
        hero.GetComponent<Hero>().maxHp -= hpDebaff;
        hero.GetComponent<Hero>().attackDamage -= damageDebaff;
        Debug.Log(name);
    }
}
