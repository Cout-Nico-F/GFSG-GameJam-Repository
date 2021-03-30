using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlimeSpawner : Spawner
{
    public SlimeSpawner()
    {
        base.spawnPoints = new Transform[5];
        base.spawnCooldown = 4f;
    }
    private void Update()
    {
        if (spawnCooldown <= 0)
        {
            Spawn();
            spawnCooldown = 4f;
        }
        else 
            spawnCooldown -= Time.deltaTime;
    }

    private void Spawn()
    {
        //check where
        int index = (int)Random.value;
        var spawnPos = spawnPoints[index];
        //spawn
        var enemy = Instantiate(base.enemy, spawnPos.position, spawnPos.rotation); //TODO: possible use of Object Pooling
    }
}
