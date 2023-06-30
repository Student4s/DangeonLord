using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCameraMover : MonoBehaviour
{
    private float _x1 = 0;
    private float _x2 = 0;

    [SerializeField] private float camSpeed;
    [SerializeField] private GameObject cam;

    private void FixedUpdate()
    {
        _x1 = Input.mousePosition.x;
        if (Input.GetMouseButton(0))
        {
            if (_x1 > _x2)
                cam.transform.Translate(-camSpeed * Time.fixedDeltaTime, 0, 0);
            if (_x2 > _x1)
                cam.transform.Translate(camSpeed * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void LateUpdate()
    {
        _x2 = Input.mousePosition.x;
    }

    public void MoveLeft()
    {
        gameObject.transform.Translate(-1, 0, 0);
    }

    public void MoveRight()
    {
        gameObject.transform.Translate(1, 0, 0);
    }
}