using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    [SerializeField] private Text text;
    private float speed = 1;
    [SerializeField] private float currentLifeTime;
    [SerializeField] private float lifeTime;
    public bool status=false;
    
    void FixedUpdate()
    {
        transform.Translate(0,speed*Time.fixedDeltaTime,0);
        currentLifeTime -= Time.fixedDeltaTime;
        
        if(currentLifeTime<=0)
            SetActive(false);
    }

    public void SetText(string txt, Transform position)
    {
        SetActive(true);
        transform.position = position.position;
        text.text = txt;
        currentLifeTime = lifeTime;
    }

    public void SetActive(bool newStatus)
    {
        gameObject.SetActive(newStatus);
        status = newStatus;
    }
}
