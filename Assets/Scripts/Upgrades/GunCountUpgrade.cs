using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCountUpgrade : Upgrade
{
    public override void ApplyUpgrade(int level)
    {
        var player = FindObjectOfType<PlayerShooting>();
        var pivot = player.pivot;
        var gun = player.guns[0];
        var radius = gun.transform.localPosition.x;

        // Limit the volume of all guns firing at once
        gun.shootSound.volume /= level;

        float angle;
        int j = 1;
        for(int i = 1; i < (level+1); i++)
        {
            // Gun clones should be in pairs with 1 gun positive and 1 gun negative of the same angle measure before increasing angle amount.
            if(i % 2 == 0)
            {
                angle = coefficient * j;
                j++;
            } else
            {
                angle = -coefficient * j;
            }
            // Sets the gun clone to a position as if the clone was rotated about the pivot point {angle} degrees from the original gun.
            Vector2 pos = new Vector2(radius * Mathf.Cos(angle * Mathf.Deg2Rad), radius * Mathf.Sin(angle * Mathf.Deg2Rad));
            Quaternion rot = Quaternion.Euler(0, 180, -angle);
            var gunClone = Instantiate(gun, pivot.transform);
            gunClone.transform.localPosition = pos;
            gunClone.transform.rotation = rot;
            gunClone.startingZ = -angle;
        }
        player.SetGuns();
    }
}
