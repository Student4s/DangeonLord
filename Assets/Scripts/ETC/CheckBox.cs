using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class CheckBox
{
    public static bool isChestSet = false;
    public static  bool isChestOpen = false;
    
   public delegate void ChestOpened();
   public static event  ChestOpened ChestOpen1;

   public static void ChestOpen()
    {
        isChestOpen = true;
        ChestOpen1();
    }
    public static void SetChest()
    { 
        isChestSet = true;
    }
}
