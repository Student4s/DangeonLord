using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{
    [SerializeField] private int effectLvl;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PerceptionCheckZone>())
        {
            col.GetComponent<PerceptionCheckZone>().AddEffect(effectLvl);
        }
    }
}
