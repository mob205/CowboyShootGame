using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMouse();
    }
    void FollowMouse()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var pivotPos = transform.position;

        mousePos.x -= pivotPos.x;
        mousePos.y -= pivotPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //float x;
        //if (angle > 90 || angle < -90)
        //{
        //    x = 180;
        //    angle = -angle;
        //} else
        //{
        //    x = 0;
        //}
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
