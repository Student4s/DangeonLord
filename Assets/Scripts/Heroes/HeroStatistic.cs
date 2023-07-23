using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatistic : MonoBehaviour
{
    //[SerializeField] private Text name;
    [SerializeField] private Text attack;
    [SerializeField] private Text attackSpeed;
    [SerializeField] private Text perception;
    [SerializeField] private Text hp;
    [SerializeField] private Text stamina;
    [SerializeField] private GameObject panel;
    [SerializeField] private Image image;

    public TraitsInfo heroTraits;

    private void Start()
    {
        Hero.GetStat += SetStats;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            
            Vector2 direction = new Vector2(0,1);
            RaycastHit2D hit2d = Physics2D.Raycast(worldPosition,direction,1000 );

            if (hit2d.collider.gameObject.GetComponent<Hero>())
            {
                hit2d.collider.gameObject.GetComponent<Hero>().Stats();
                SetTraits(hit2d.collider.gameObject.GetComponent<TraitList>());
            }
                
        }
    }

    public void SetStats(float perception, float hp, float stamina, float attack, float attackSpeed, Sprite image)
    {
        panel.SetActive(true);
        this.attack.text ="Attack: " + attack.ToString();
        this.perception.text ="Perception: " + perception.ToString();
        this.hp.text ="HP: "+ hp.ToString();
        this.stamina.text ="Stamina: "+ stamina.ToString();
        this.attackSpeed.text ="AS: "+ attackSpeed.ToString();
        this.image.sprite =image;
    }

    public void SetTraits(TraitList trits)
    {
        for (int i = 0; i < trits.traits.Count; i++)
            heroTraits.traits[i].text = trits.traits[i].name;
    }

    private void OnDisable()
    {
        Hero.GetStat -= SetStats;
    }
}
