using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    bool isSpawningWood, isSpawningStone, isSpawningWater, isSpawningCrystal = false;

    public bool IsSpawningWood { get => isSpawningWood; set => isSpawningWood = value; }
    public bool IsSpawningStone { get => isSpawningStone; set => isSpawningStone = value; }
    public bool IsSpawningWater { get => isSpawningWater; set => isSpawningWater = value; }
    public bool IsSpawningCrystal { get => isSpawningCrystal; set => isSpawningCrystal = value; }

    private void Update()
    {
        
        SpawnBasic();
        if (isSpawningWood)
        {
            SpawnWood();
        }
        if (isSpawningStone)
        {
            SpawnStone();
        }
        if (IsSpawningWater)
        {
            SpawnWater();
        }
        if (isSpawningCrystal)
        {
            SpawnCrystal();
        }
    }

    private void SpawnCrystal()
    {
        throw new NotImplementedException();
    }

    private void SpawnWater()
    {
        throw new NotImplementedException();
    }

    private void SpawnStone()
    {
        throw new NotImplementedException();
    }

    private void SpawnWood()
    {
        throw new NotImplementedException();
    }

    private void SpawnBasic()
    {

        throw new NotImplementedException();
    }
}
