using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivable : Trait
{
    [SerializeField] private float hpBaff;
    public override void Use(GameObject hero)
    {
        hero.GetComponent<Hero>().hp += hpBaff;
        hero.GetComponent<Hero>().maxHp += hpBaff;
    }
}
