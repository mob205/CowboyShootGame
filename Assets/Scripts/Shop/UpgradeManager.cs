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

    Dictionary<Upgrade, int> upgrades = new Dictionary<Upgrade, int>();

    public void AddUpgrade(Upgrade upgrade, int level)
    {
        upgrades[upgrade] = level;
    }
    public void ApplyUpgrades()
    {
        Debug.Log("Applying upgrades.");
        foreach(Upgrade upgrade in upgrades.Keys)
        {
            upgrade.ApplyUpgrade(upgrades[upgrade]);
        }
    }
}
