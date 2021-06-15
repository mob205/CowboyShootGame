using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var guns = FindObjectsOfType<GunController>();
        foreach(var gun in guns)
        {
            gun.bulletSpeed += coefficient * level;
        }
    }
}
