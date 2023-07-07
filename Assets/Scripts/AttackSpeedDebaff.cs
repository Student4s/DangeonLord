using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedDebaff : MonoBehaviour
{
    [SerializeField] private float number;
    [SerializeField] private int percent;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<HeroesEffects>())
        {
            col.GetComponent<HeroesEffects>().AttackSpeedChange(number, percent);
        }
    }
}
