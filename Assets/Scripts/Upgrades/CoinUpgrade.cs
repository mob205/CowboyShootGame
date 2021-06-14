﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        CoinCounter.coinModifier = 1 + (coefficient * level);
    }
}
