using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        FindObjectOfType<GunController>().bulletSpeed += coefficient * level;
    }
}
