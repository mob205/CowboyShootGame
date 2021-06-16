using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    Camera mainCamera;
    public Vector3 target;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        FollowMouse();
    }
    public void SetTarget(Vector3 newTarget) 
    {
        target = newTarget;
    }
    void FollowMouse()
    {
        var pivotPos = transform.position;

        target.x -= pivotPos.x;
        target.y -= pivotPos.y;

        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"Target Coords: ({target.x}, {target.y})");
        Debug.Log($"Mouse pos coords: ({mousePos.x}, {mousePos.y})");

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
