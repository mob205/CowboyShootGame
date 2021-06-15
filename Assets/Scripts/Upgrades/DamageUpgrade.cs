using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var guns = FindObjectsOfType<GunController>();
        foreach(var gun in guns)
        {
            gun.damage += coefficient * level;
        }
    }
}
