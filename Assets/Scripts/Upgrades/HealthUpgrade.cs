using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        PlayerController.instance.baseHealth += coefficient * level;
    }
}
