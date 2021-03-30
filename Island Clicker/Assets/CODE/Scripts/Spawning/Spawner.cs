using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField]
    protected float spawnCooldown;
    [SerializeField]
    protected Transform[] spawnPoints;
    [SerializeField]
    protected Enemy enemy;
    
}
