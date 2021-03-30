using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    protected bool isUnlocked;
    protected int unlockScore;

    public bool ActiveFlag { get => isUnlocked; }
    public int ActivationScore { get => unlockScore; }

    public abstract void Unlock();
    //public abstract void ActivationScoreCheck();
}
