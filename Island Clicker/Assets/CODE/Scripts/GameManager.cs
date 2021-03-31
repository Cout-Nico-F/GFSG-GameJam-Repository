using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int speedGodMode = 0;
    private float spawnGodMode = 10;
    //Resources
    Forest forest;
    Mountain mountain;
    River river;
    Crystals crystal;
    //UI
    UiManager uiManager;
    //Enemy
    public enum EnemyTypes
    {
        Slime,
        Wood,
        Rock,
        Water,
        Crystal
    }
    //Spawners
    [SerializeField]
    GameObject slimeSpawner;
    [SerializeField]
    GameObject woodSpawner;
    [SerializeField]
    GameObject rockSpawner;
    [SerializeField]
    GameObject waterSpawner;
    [SerializeField]
    GameObject crystalSpawner;

    private void Start()
    {
        forest = FindObjectOfType<Forest>();
        mountain = FindObjectOfType<Mountain>();
        river = FindObjectOfType<River>();
        crystal = FindObjectOfType<Crystals>();

        uiManager = FindObjectOfType<UiManager>();

        //initialize the static references.
        StaticReference.Sword = FindObjectOfType<Sword>();
        StaticReference.Target = FindObjectOfType<House>().transform;
        StaticReference.GameManager = this;
    }

    public void EnemyDied(Enemy enemy)
    {

        Stats.Experience += enemy.Exp;
        uiManager.UpdateExperience();

        AssignLootStats(enemy);
        uiManager.UpdateIcons(enemy.EnemyType);


        UnlockResourcesByExperience();
    }

    private void AssignLootStats(Enemy enemy)
    {
        switch (enemy.EnemyType)
        {
            case GameManager.EnemyTypes.Slime:
                break;

            case GameManager.EnemyTypes.Wood:
                if (Stats.Wood < uiManager.MaxWood)
                {
                    Stats.Wood += enemy.LootAmmount;
                }
                else Stats.Wood = uiManager.MaxWood;
                break;

            case GameManager.EnemyTypes.Rock:
                if (Stats.Rock < uiManager.MaxRock)
                {
                    Stats.Rock += enemy.LootAmmount;
                }
                else Stats.Rock = uiManager.MaxRock;
                break;

            case GameManager.EnemyTypes.Water:
                if (Stats.Water < uiManager.MaxWater)
                {
                    Stats.Water += enemy.LootAmmount;
                }
                else Stats.Water = uiManager.MaxWater;
                break;

            case GameManager.EnemyTypes.Crystal:
                if (Stats.Crystal < uiManager.MaxCrystals)
                {
                    Stats.Crystal += enemy.LootAmmount;
                }
                else Stats.Crystal = uiManager.MaxCrystals;
                break;

            default:
                break;
        }
    }
    public void ActivateSpawners(EnemyTypes enemy)
    {
        switch (enemy)
        {
            case EnemyTypes.Slime:
                break;
            case EnemyTypes.Wood:
                woodSpawner.SetActive(true);
                break;
            case EnemyTypes.Rock:
                rockSpawner.SetActive(true);
                break;
            case EnemyTypes.Water:
                waterSpawner.SetActive(true);
                break;
            case EnemyTypes.Crystal:
                crystalSpawner.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void UnlockResourcesByExperience()
    {
        if (Stats.Experience >= crystal.ActivationScore && crystal.ActiveFlag == false)
        {
            crystal.Unlock();
        }
        else if (Stats.Experience > river.ActivationScore && river.ActiveFlag == false)
        {
            river.Unlock();
        }
        else if (Stats.Experience > mountain.ActivationScore && mountain.ActiveFlag == false)
        {
            mountain.Unlock();
        }
        else
        if (Stats.Experience > forest.ActivationScore && forest.ActiveFlag == false)
        {
            forest.Unlock();
        }
    }

    public void SpeedGodMode()
    {
        if (speedGodMode < 5)
        {
            Enemy.speedMultiplier = 5;
            speedGodMode = 5;
        }
        else if (speedGodMode < 15)
        {
            Enemy.speedMultiplier = 15;
            speedGodMode = 15;
        }
        else
        {
            Enemy.speedMultiplier = 1;
            speedGodMode = 0;
        }
    }

    public void SpawnGodMode()
    {
        if (spawnGodMode > 2)
        {
            slimeSpawner.GetComponent<SlimeSpawner>().SpawnCooldown = 2;
            slimeSpawner.GetComponent<SlimeSpawner>().CooldownResetNumber = 2;
            woodSpawner.GetComponent<WoodSpawner>().SpawnCooldown = 2;
            woodSpawner.GetComponent<WoodSpawner>().CooldownResetNumber = 2;
            rockSpawner.GetComponent<RockSpawner>().SpawnCooldown = 2;
            rockSpawner.GetComponent<RockSpawner>().CooldownResetNumber = 2;
            waterSpawner.GetComponent<WaterSpawner>().SpawnCooldown = 2;
            waterSpawner.GetComponent<WaterSpawner>().CooldownResetNumber = 2;
            crystalSpawner.GetComponent<CrystalSpawner>().SpawnCooldown = 2;
            crystalSpawner.GetComponent<CrystalSpawner>().CooldownResetNumber = 2;
            spawnGodMode = 2;
        }
        else if (spawnGodMode > 0.4f)
        {
            slimeSpawner.GetComponent<SlimeSpawner>().SpawnCooldown = 0.4f;
            slimeSpawner.GetComponent<SlimeSpawner>().CooldownResetNumber = 0.4f;
            woodSpawner.GetComponent<WoodSpawner>().SpawnCooldown = 0.4f;
            woodSpawner.GetComponent<WoodSpawner>().CooldownResetNumber = 0.4f;
            rockSpawner.GetComponent<RockSpawner>().SpawnCooldown = 0.4f;
            rockSpawner.GetComponent<RockSpawner>().CooldownResetNumber = 0.4f;
            waterSpawner.GetComponent<WaterSpawner>().SpawnCooldown = 0.4f;
            waterSpawner.GetComponent<WaterSpawner>().CooldownResetNumber = 0.4f;
            crystalSpawner.GetComponent<CrystalSpawner>().SpawnCooldown = 0.4f;
            crystalSpawner.GetComponent<CrystalSpawner>().CooldownResetNumber = 0.4f;
            spawnGodMode = 0.4f;
        }
        else
        {
            slimeSpawner.GetComponent<SlimeSpawner>().SpawnCooldown = 3;
            slimeSpawner.GetComponent<SlimeSpawner>().CooldownResetNumber = 3;
            woodSpawner.GetComponent<WoodSpawner>().SpawnCooldown = 4;
            woodSpawner.GetComponent<WoodSpawner>().CooldownResetNumber = 4;
            rockSpawner.GetComponent<RockSpawner>().SpawnCooldown = 5;
            rockSpawner.GetComponent<RockSpawner>().CooldownResetNumber = 5;
            waterSpawner.GetComponent<WaterSpawner>().SpawnCooldown = 5;
            waterSpawner.GetComponent<WaterSpawner>().CooldownResetNumber = 5;
            crystalSpawner.GetComponent<CrystalSpawner>().SpawnCooldown = 5;
            crystalSpawner.GetComponent<CrystalSpawner>().CooldownResetNumber = 5;
            spawnGodMode = 10;
        }
    }


}
