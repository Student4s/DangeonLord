using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCameraMover : MonoBehaviour
{


   public void MoveLeft()
    {
        gameObject.transform.Translate(-1,0,0);
    }
    
   public void MoveRight()
    {
        gameObject.transform.Translate(1,0,0);
    }
}
