using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        Debug.Log("Applying upgrade with a level of " + level);
    }
}
