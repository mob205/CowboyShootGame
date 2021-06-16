using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPivot : MonoBehaviour
{
    [HideInInspector] public Vector3 target;

    private void Start()
    {
        FollowMouse();
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

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
