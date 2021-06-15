using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var guns = FindObjectsOfType<GunController>();
        var reloadTime = Mathf.Pow(coefficient, -level);
        foreach(var gun in guns)
        {
            gun.reloadTime = reloadTime;
        }
    }
}
