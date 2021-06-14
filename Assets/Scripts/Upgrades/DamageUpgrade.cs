using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        FindObjectOfType<GunController>().damage += coefficient * level;
    }
}
