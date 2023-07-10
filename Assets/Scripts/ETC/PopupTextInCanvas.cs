using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTextInCanvas : MonoBehaviour
{
    [SerializeField] private PopupText pos;
    [SerializeField] private List<PopupText> poolTexts;
    void Awake()
    {
        Hero.Accses += DisplayText;
        poolTexts = new List<PopupText>();
    }

    public void DisplayText(string text, Transform position)
    {
        if(poolTexts.Count==0)
            CreateNew();
        
        for (int i = 0; i < poolTexts.Count; i++)
        {
            if (!poolTexts[i].status)
            {
                poolTexts[i].SetText(text,position);
                return;
            }
        }
        CreateNew();
        for (int i = 0; i <= poolTexts.Count; i++)
        {
            if (!poolTexts[i].status)
            {
                poolTexts[i].SetText(text,position);
                return;
            }
        }
    }

    void CreateNew()
    {
        PopupText A = Instantiate(pos,gameObject.transform);
        A.status = false;
        poolTexts.Add(A);
    }
    
    private void OnDisable()
    {
        Hero.Accses -= DisplayText;
    }
}
