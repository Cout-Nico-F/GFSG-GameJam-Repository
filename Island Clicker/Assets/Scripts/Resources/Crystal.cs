using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Resource
{
    public Crystal()
    {
        base.isUnlocked = false;
        base.unlockScore = 10000;
    }

    public override void Unlock()
    {
        base.isUnlocked = true;
    }
}
