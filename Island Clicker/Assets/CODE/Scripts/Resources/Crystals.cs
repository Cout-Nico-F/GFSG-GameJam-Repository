using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : Resource
{
    public Crystals()
    {
        base.isUnlocked = false;
        base.unlockScore = 8000;
    }

    public override void Unlock()
    {
        base.isUnlocked = true;
        StaticReference.GameManager.ActivateSpawners(GameManager.EnemyTypes.Crystal);
    }
}
