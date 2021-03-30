using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    bool wood, stone, water, crystal = false;
    private void Update()
    {
        SpawnBasic();
        if (wood)
        {
            SpawnWood();
        }
        if (stone)
        {
            SpawnStone();
        }
        if (water)
        {
            SpawnWater();
        }
        if (crystal)
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
