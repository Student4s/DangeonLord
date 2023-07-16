using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitList : MonoBehaviour
{
    public List<Trait> traits;
    void Start()
    {
        for (int i = 0; i < traits.Count; i++)
        {
            traits[i].Use(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
