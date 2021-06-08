using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUpgrade : Upgrade
{
    public override void ApplyUpgrade()
    {
        Debug.Log("OVERRIDE");
    }
}
