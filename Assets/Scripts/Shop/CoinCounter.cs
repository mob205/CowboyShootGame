using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinCounter
{
    public static int Coins { get; private set; }

    public static float coinModifier = 1;

    public static void AddCoins(int amount)
    {
        Coins += Mathf.RoundToInt(amount * coinModifier);
    }
    public static void RemoveCoins(int amount)
    {
        Coins -= amount;
    }
}
