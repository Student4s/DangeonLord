using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myopic : Trait
{
    [SerializeField] private int perceptionDebaff;
    public override void Use(GameObject hero)
    {
        hero.GetComponent<Hero>().perception -= perceptionDebaff;
    }
}
