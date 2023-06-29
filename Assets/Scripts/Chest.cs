using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Traps
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Hero>())
        {
            CheckBox.ChestOpen();
            Destroy(gameObject);
        }
            
    }
}
