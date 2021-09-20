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
    void LateUpdate()
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
        var rotTarget = new Vector2(target.x - pivotPos.x, target.y - pivotPos.y);

        float angle = Mathf.Atan2(rotTarget.y, rotTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
