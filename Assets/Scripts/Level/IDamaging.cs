using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamaging
{
    event EventHandler<float> DamageDealtEventHandler;
    void OnDamageDealt(object source, float amount);
}
