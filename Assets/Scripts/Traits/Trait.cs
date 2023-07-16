using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trait : MonoBehaviour
{

    virtual public void Use(GameObject hero)
    {
        Debug.Log("Trait use");
    }
}
