using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionCheckZone : MonoBehaviour
{
    [SerializeField] private int needPerception;
    [SerializeField] private GameObject trap;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Hero>())
            col.GetComponent<Hero>().Trap(needPerception, trap);
    }

    public void AddEffect(int perception)
    {
        needPerception += perception;
    }
}
