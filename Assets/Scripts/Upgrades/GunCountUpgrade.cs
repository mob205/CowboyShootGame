using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCountUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var pivot = FindObjectOfType<GunPivot>();
        var gun = FindObjectOfType<GunController>();
        var radius = gun.transform.localPosition.x;
        float angle;
        for(int i = 1; i < (level+1); i++)
        {
            if(i % 2 == 0)
            {
                angle = coefficient * i;
            } else
            {
                angle = -coefficient * i;
            }
            Debug.Log($"Angle: {angle}");
            Vector2 pos = new Vector2(radius * Mathf.Cos(angle * Mathf.Deg2Rad), radius * Mathf.Sin(angle * Mathf.Deg2Rad));
            Debug.Log($"Calculated X: {pos.x} | Calculated Y: {pos.y}");
            Quaternion rot = Quaternion.Euler(0, 180, -angle);
            var gunClone = Instantiate(gun, pivot.transform);
            gunClone.transform.localPosition = pos;
            gunClone.transform.rotation = rot;
            gunClone.startingZ = -angle;
        }
    }
}
