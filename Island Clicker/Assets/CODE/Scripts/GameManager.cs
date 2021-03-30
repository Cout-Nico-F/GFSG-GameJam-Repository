using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

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
        uiManager.UpdateText();
        //lootManager.DropLoot ?
        //Decide what to drop based on the type of enemy ?

        UnlockResourcesByExperience();
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


}
