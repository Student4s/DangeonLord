using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionCheckZone : MonoBehaviour
{
    [SerializeField] private float needPerception;
    [SerializeField] private GameObject trap;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Hero>())
        {
            if (col.GetComponent<Hero>().PerceptionCheck(needPerception))
                Destroy(trap.gameObject);
        }
            
    }
}
