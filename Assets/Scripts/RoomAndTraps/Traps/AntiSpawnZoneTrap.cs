using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSpawnZoneTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Traps>())
            col.GetComponent<Traps>().ChangeIsCanBuild(false);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Traps>())
            col.GetComponent<Traps>().ChangeIsCanBuild(true);
    }
}
