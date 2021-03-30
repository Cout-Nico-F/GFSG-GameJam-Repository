using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : Resource
{
    public River()
    {
        base.isUnlocked = false;
        base.unlockScore = 1500;
    }

    public override void Unlock()
    {
        base.isUnlocked = true;
        StaticReference.GameManager.ActivateSpawners(GameManager.EnemyTypes.Water);
    }
}
