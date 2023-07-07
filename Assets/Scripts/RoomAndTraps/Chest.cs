using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Traps
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Hero>())
        {
            CheckBox.ChestOpen();
            Destroy(gameObject);
        }
            
    }
}
