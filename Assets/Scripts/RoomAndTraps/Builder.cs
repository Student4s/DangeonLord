using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [SerializeField] private int currentGold=10;
    [SerializeField] private Text scoreTxt;
    
    [SerializeField] private BasedEnemy[] enemys;
    [SerializeField] private Traps[] traps;
    [SerializeField] private GameObject grid;

    private bool _isBuildTrap = false;
    private Traps _trap;
    private int _currentTrapNumber;
    
    private bool _isSpawnEnemy = false;
    private BasedEnemy _enemy;
    private int _currentEnemyNumber;

    private void Start()
    {
        ScoreTxtUpdate();
    }

    private void FixedUpdate()
    {
        if (_isBuildTrap)
            IfBuildTrap();

        if (_isSpawnEnemy) 
            IfSpawnEnemy();

    }
    public void SpawnEnemy(int enemyNumber)
    {
        _currentEnemyNumber = enemyNumber;
        if (currentGold >= enemys[enemyNumber].price)
        {
            currentGold -= enemys[enemyNumber].price;
            ScoreTxtUpdate();
            _isSpawnEnemy = true;
            _enemy = Instantiate(enemys[enemyNumber],grid.transform );
        }
    }
    public void BuildTrap(int trapNumber)
    {
        _currentTrapNumber = trapNumber;
        if (currentGold >= traps[trapNumber].price)
        {
            currentGold -= traps[trapNumber].price;
            ScoreTxtUpdate();
            _isBuildTrap = true;
            _trap = Instantiate(traps[trapNumber],grid.transform );
        }
    }
   
    void ScoreTxtUpdate()
    {
        scoreTxt.text = currentGold.ToString();
    }

    void IfBuildTrap()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            
        _trap.transform.position = new Vector3(worldPosition.x, worldPosition.y,0);
        if (Input.GetMouseButton(0))
        {
            if(_currentTrapNumber==0)
                CheckBox.SetChest();
                
            Traps newTrap = Instantiate(traps[_currentTrapNumber], grid.transform);
            newTrap.GetComponent<Rigidbody2D>().gravityScale = 1;
            newTrap.transform.position = _trap.transform.position;
            Destroy(_trap.gameObject);
            _isBuildTrap = false;
            ScoreTxtUpdate();
        }
        if (Input.GetMouseButton(1))
        {
            currentGold += traps[_currentTrapNumber].price;
            Destroy(_trap.gameObject);
            _isBuildTrap = false;
            ScoreTxtUpdate();
        }
    }

    void IfSpawnEnemy()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            
        _enemy.transform.position = new Vector3(worldPosition.x, worldPosition.y,0);
        if (Input.GetMouseButton(0))
        {
            BasedEnemy newEnemy = Instantiate(enemys[_currentEnemyNumber], grid.transform);
            newEnemy.GetComponent<Rigidbody2D>().gravityScale = 1;
            newEnemy.transform.position = _enemy.transform.position;
            Destroy(_enemy.gameObject);
            _isSpawnEnemy = false;
            ScoreTxtUpdate();
        }
        if (Input.GetMouseButton(1))
        {
            currentGold += enemys[_currentEnemyNumber].price;
            Destroy(_enemy.gameObject);
            _isSpawnEnemy = false;
            ScoreTxtUpdate();
        }
    }
}
