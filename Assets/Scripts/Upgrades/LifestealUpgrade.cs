using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestealUpgrade : Upgrade
{
    int level;
    public override void ApplyUpgrade(int level)
    {
        PlayerController.instance.DamageDealtEventHandler += HealFromDamage;
        this.level = level;
    }
    void HealFromDamage(object source, float amount)
    {
        Debug.Log("Attempting to lifesteal");
        PlayerController.instance.Heal(amount * coefficient * level);
    }
}
