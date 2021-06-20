using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUpgrade : Upgrade
{
    [SerializeField] float minimumVolume;
    public override void ApplyUpgrade(int level)
    {
        var guns = FindObjectsOfType<GunController>();
        var reloadTime = Mathf.Pow(coefficient, -level);
        foreach(var gun in guns)
        {
            gun.reloadTime = reloadTime;
            // Limit the sound of the firing sound effect overlapping with itself at higher levels
            gun.shootSound.volume *= Mathf.Clamp01(reloadTime + 0.1f);
        }
    }
}
