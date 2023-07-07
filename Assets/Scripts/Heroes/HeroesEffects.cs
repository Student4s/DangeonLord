using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesEffects : MonoBehaviour
{
    private Hero _hero;
    void Start()
    {
        _hero = gameObject.GetComponent<Hero>();
    }

    public void AttackSpeedChange(float number, int percent)
    {
        _hero.attackSpeed += number;
        _hero.attackSpeed += _hero.attackSpeed*percent/100;
        
    }
}
