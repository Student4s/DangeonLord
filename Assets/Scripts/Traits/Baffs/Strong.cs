using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strong : Trait
{
    [SerializeField] private float hpBaff;
    [SerializeField] private float damageBaff;
    public override void Use(GameObject hero)
    {
        hero.GetComponent<Hero>().hp += hpBaff;
        hero.GetComponent<Hero>().maxHp += hpBaff;
        hero.GetComponent<Hero>().attackDamage += damageBaff;
        Debug.Log(name);
    }
}
