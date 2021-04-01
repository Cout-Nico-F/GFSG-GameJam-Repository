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
    Crystals crystals;
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
    [Space]
    [SerializeField]
    GameObject house;

    private int speedGodMode = 0;
    private float spawnGodMode = 10;
    private bool isHealthGodMode;
    private bool isPaused;


    private void Start()
    {
        forest = FindObjectOfType<Forest>();
        mountain = FindObjectOfType<Mountain>();
        river = FindObjectOfType<River>();
        crystals = FindObjectOfType<Crystals>();

        house = FindObjectOfType<House>().gameObject;

        uiManager = FindObjectOfType<UiManager>();

        //initialize the static references.
        StaticReference.Sword = FindObjectOfType<Sword>();
        StaticReference.Target = FindObjectOfType<House>().transform;
        StaticReference.GameManager = this;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            uiManager.ShowPauseUi(true);
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            uiManager.ShowPauseUi(false);
        }
    }
    public void WinGame()
    {
        Time.timeScale = 0;
        uiManager.ShowWinUi();
    }
    public void HouseDestroyed()//GameOver
    {
        uiManager.ShowGameOverUi();
        AudioManager.instance.Stop("NoStar-Music");
        AudioManager.instance.Stop("WoodStar-Music");
        AudioManager.instance.Stop("RockStar-Music");
        AudioManager.instance.Stop("WaterStar-Music");
        AudioManager.instance.Stop("CrystalStar-Music");
        AudioManager.instance.Play("HouseDestroyed");
    }
    public void EnemyDied(Enemy enemy)
    {

        Stats.Experience += enemy.Exp;

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
        if (Stats.Experience >= crystals.ActivationScore && crystals.ActiveFlag == false)
        {
            crystals.Unlock();
            uiManager.UpdateExperienceLevel(GameManager.EnemyTypes.Crystal);
            AudioManager.instance.Play("CrystalUnlocked");
            AudioManager.instance.Play("CrystalStar-Music");
            StartCoroutine(WaitForSecondsCoroutine(0.1f));
            AudioManager.instance.Stop("WaterStar-Music"); 
        }
        else if (Stats.Experience > river.ActivationScore && river.ActiveFlag == false)
        {
            river.Unlock();
            uiManager.UpdateExperienceLevel(GameManager.EnemyTypes.Water);
            AudioManager.instance.Play("WaterUnlocked");
            AudioManager.instance.Play("WaterStar-Music");
            StartCoroutine(WaitForSecondsCoroutine(0.1f));
            AudioManager.instance.Stop("RockStar-Music");

        }
        else if (Stats.Experience > mountain.ActivationScore && mountain.ActiveFlag == false)
        {
            mountain.Unlock();
            uiManager.UpdateExperienceLevel(GameManager.EnemyTypes.Rock);
            AudioManager.instance.Play("RockUnlocked");
            AudioManager.instance.Play("RockStar-Music");
            StartCoroutine(WaitForSecondsCoroutine(0.1f));
            AudioManager.instance.Stop("WoodStar-Music");
        }
        else
        if (Stats.Experience > forest.ActivationScore && forest.ActiveFlag == false)
        {
            forest.Unlock();
            uiManager.UpdateExperienceLevel(GameManager.EnemyTypes.Wood);
            AudioManager.instance.Play("WoodUnlocked");
            AudioManager.instance.Play("WoodStar-Music");
            StartCoroutine(WaitForSecondsCoroutine(0.1f));
            AudioManager.instance.Stop("NoStar-Music");
        }
    }
    IEnumerator WaitForSecondsCoroutine( float seconds)
    {
        //Wait for X seconds
        yield return new WaitForSecondsRealtime(seconds);
    }
    //Developer tools ( God Mode )
    public void HealthGodMode()
    {
        if (!isHealthGodMode)
        {
            house.GetComponent<BoxCollider2D>().enabled = false;
            isHealthGodMode = true;
        }
        else
        {
            house.GetComponent<BoxCollider2D>().enabled = true;
            isHealthGodMode = false;
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
