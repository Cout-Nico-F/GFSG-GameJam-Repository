using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : Resource
{
    public Mountain()
    {
        base.isUnlocked = false;
        base.unlockScore = 500;
    }

    public override void Unlock()
    {
        base.isUnlocked = true;
    }
}
