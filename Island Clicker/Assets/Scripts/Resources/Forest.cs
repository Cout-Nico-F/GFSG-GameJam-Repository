using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Resource
{
    public Forest()
    {
        base.isUnlocked = false;
        base.unlockScore = 100;
    }

    public override void Unlock()
    {
        base.isUnlocked = true;
    }

    //public override void ActivationScoreCheck()
    //{
    //    if (isUnlocked == false && Stats.Score > ActivationScore)
    //    {
    //        Unlock();
    //    }
    //}
}
