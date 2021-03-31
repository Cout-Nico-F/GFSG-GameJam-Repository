using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WoodSpawner : Spawner
{
    public WoodSpawner()
    {
        base.spawnPoints = new Transform[5];
        base.spawnCooldown = 4f; 
        base.cooldownResetNumber = base.spawnCooldown;
    }
    private void Update()
    {
        if (spawnCooldown <= 0)
        {
            Spawn();
            spawnCooldown = base.cooldownResetNumber;
        }
        else 
            spawnCooldown -= Time.deltaTime;
    }

    private void Spawn()
    {
        //check where
        int index = (int)Random.Range(0,4);
        var spawnPos = spawnPoints[index];
        //spawn
        var enemy = Instantiate(base.enemy, spawnPos.position, spawnPos.rotation); //TODO: possible use of Object Pooling
    }
}
