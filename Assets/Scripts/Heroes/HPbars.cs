using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbars : MonoBehaviour
{
    [SerializeField] private Image hp;
    [SerializeField] private Image stamina;

    void Start()
    {
        Hero.UpdateBars += UpdateBars;
    }


    void UpdateBars(float hp, float maxHP, float stamina, float maxStamina)
    {
        this.hp.gameObject.SetActive(true);
        this.stamina.gameObject.SetActive(true);
        this.hp.fillAmount = hp / maxHP;
        this.stamina.fillAmount = stamina / maxStamina;
    }

    private void OnDisable()
    {
        Hero.UpdateBars -= UpdateBars;
    }
}
