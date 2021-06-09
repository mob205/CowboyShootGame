using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public int costFactor;
    public int maxLevel = 99;

    public virtual int GetCost(int level)
    {
        return costFactor * level;
    }
    public virtual void ApplyUpgrade(int level)
    {
        
    }
}
