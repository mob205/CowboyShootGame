using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public int level = 1;
    public int cost
    {
        get
        {
            return costFactor * level;
        }
    }
    public int costFactor;

    public virtual void ApplyUpgrade()
    {
        
    }
}
