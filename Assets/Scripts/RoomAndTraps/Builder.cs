using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    [SerializeField] private int currentGold=10;
    [SerializeField] private Text scoreTxt;
    
    
    [SerializeField] private int length;
    [SerializeField] private DungeonRoom[] rooms;
    [SerializeField] private Traps[] traps;
    [SerializeField] private Traps[] trapsPict;
    [SerializeField] private GameObject grid;

    private bool _isBuildTrap = false;
    private Traps _trap;
    private int _currentTrapNumber;

    private void Start()
    {
        ScoreTxtUpdate();
    }

    public void BuildRoom(int roomNumber)
    {
        if (currentGold >= rooms[roomNumber].price)
        {
            currentGold -= rooms[roomNumber].price;
            ScoreTxtUpdate();
            DungeonRoom newRoom = Instantiate(rooms[roomNumber],grid.transform );
            newRoom.transform.position = new Vector3(length, 0, 0);
            length += newRoom.length;
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
    private void FixedUpdate()
    {
        if (_isBuildTrap)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            //Debug.Log(worldPosition);
            _trap.transform.position = new Vector3(worldPosition.x, worldPosition.y,0);
            if (Input.GetMouseButtonDown(0))
            {
                if(_currentTrapNumber==0)
                    CheckBox.SetChest();
                
                
                var A = Instantiate(traps[_currentTrapNumber], grid.transform);
                A.GetComponent<Rigidbody2D>().gravityScale = 1;
                A.transform.position = _trap.transform.position;
                Destroy(_trap.gameObject);
                _isBuildTrap = false;
            }
        }
    }
    void ScoreTxtUpdate()
    {
        scoreTxt.text = currentGold.ToString();
    }
}
