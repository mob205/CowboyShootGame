using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var playerGun = FindObjectOfType<GunController>();
        playerGun.reloadTime /= level + 1; // Reload time reduction algorithm here
    }
}
