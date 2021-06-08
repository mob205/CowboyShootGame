using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager instance;
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    List<Upgrade> upgrades = new List<Upgrade>();

    public void AddUpgrade(Upgrade upgrade)
    {
        upgrades.Add(upgrade);
    }
    public void ApplyUpgrades()
    {
        foreach(Upgrade upgrade in upgrades)
        {
            upgrade.ApplyUpgrade();
        }
    }
}
