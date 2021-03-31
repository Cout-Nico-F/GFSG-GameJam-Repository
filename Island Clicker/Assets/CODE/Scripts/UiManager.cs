using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UiManager : MonoBehaviour
{
    //el GM le tiene que avisar cuando un stat cambia 
    //Posee un metodo conversor de numero a cantidad de sprites activos
    //hay una lista donde estan los sprites que todavia no se activaron
    //hay otra lista copia de la anterior que se mantiene intacta para poder desactivarlos al gastarlo ?
    //se hace un random para activar uno de esos, y sacarlo de la lista
    //se activa uno cada X cantidad de un sprite.
    //le avisan que cambio y tiene un metodo que va a decir si tenes 100 madera = 10 maderitas 

    private int maxWood = 90;
    private int maxRock = 28;
    private int maxWater = 225;
    private int maxCrystals = 18;

    private int woodAmmountPerIcon = 10;
    private int rockAmmountPerIcon = 4;
    private int waterAmmountPerIcon = 25;
    private int crystalAmmountPerIcon = 2;

    [SerializeField]
    private List<GameObject> inactiveWoodIcons, inactiveRockIcons, inactiveWaterIcons, inactiveCrystalIcons;
    private List<GameObject> activeWoodIcons, activeRockIcons, activeWaterIcons, activeCrystalIcons;
    [SerializeField]
    private GameObject  hearts1, hearts2, hearts3, hearts4, hearts5, hearts6;

    public int MaxWood { get => maxWood; }
    public int MaxRock { get => maxRock; }
    public int MaxWater { get => maxWater; }
    public int MaxCrystals { get => maxCrystals; }

    private void Awake()
    {
        activeCrystalIcons = new List<GameObject>();
        activeWoodIcons = new List<GameObject>();
        activeRockIcons = new List<GameObject>();
        activeWaterIcons = new List<GameObject>();
    }

    public void UpdateExperience()
    {
        //tmp.text = "Experience: " + Stats.Experience;
    }

    public void UpdateIcons(GameManager.EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case GameManager.EnemyTypes.Slime:
                break;
            case GameManager.EnemyTypes.Wood:
                if (Stats.Wood >= woodAmmountPerIcon * (activeWoodIcons.Count + 1))
                {
                    ActivateIcon(activeWoodIcons, inactiveWoodIcons);
                }
                break;
            case GameManager.EnemyTypes.Rock:
                if (Stats.Rock >= rockAmmountPerIcon * (activeRockIcons.Count + 1))
                {
                    ActivateIcon(activeRockIcons, inactiveRockIcons);
                }
                break;
            case GameManager.EnemyTypes.Water:
                if (Stats.Water >= waterAmmountPerIcon * (activeWaterIcons.Count + 1))
                {
                    ActivateIcon(activeWaterIcons, inactiveWaterIcons);
                }
                break;
            case GameManager.EnemyTypes.Crystal:
                if (Stats.Crystal >= crystalAmmountPerIcon * (activeCrystalIcons.Count + 1))
                {
                    ActivateIcon(activeCrystalIcons, inactiveCrystalIcons);
                }
                break;
            default:
                break;
        }
    }

    public void UpdateHealth( int health )
    {
        switch (health)
        {
            case 0:
                hearts1.SetActive(false);
                break;
            case 1:
                hearts2.SetActive(false);
                hearts1.SetActive(true);
                break;
            case 2:
                hearts3.SetActive(false);
                hearts2.SetActive(true);
                break;
            case 3:
                hearts4.SetActive(false);
                hearts3.SetActive(true);
                break;
            case 4:
                hearts5.SetActive(false);
                hearts4.SetActive(true);
                break;
            case 5:
                hearts6.SetActive(false);
                hearts5.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void SpentMaterials(GameManager.EnemyTypes enemyType, int amount)
    {
        List<GameObject> activeList = null;
        List<GameObject> inActiveList = null;
        switch (enemyType)
        {
            case GameManager.EnemyTypes.Slime:
                break;
            case GameManager.EnemyTypes.Wood:
                activeList = activeWoodIcons;
                inActiveList = inactiveWoodIcons;
                amount /= woodAmmountPerIcon;
                break;
            case GameManager.EnemyTypes.Rock:
                activeList = activeRockIcons;
                inActiveList = inactiveRockIcons;
                amount /= rockAmmountPerIcon;
                break;
            case GameManager.EnemyTypes.Water:
                activeList = activeWaterIcons;
                inActiveList = inactiveWaterIcons;
                amount /= waterAmmountPerIcon;
                break;
            case GameManager.EnemyTypes.Crystal:
                activeList = activeCrystalIcons;
                inActiveList = inactiveCrystalIcons;
                amount /= crystalAmmountPerIcon;
                break;
            default:
                break;
        }

        for (int i = 0; i < amount; i++)
        {
            int index = (int)UnityEngine.Random.Range(0, activeList.Count - 1);
            activeList[index].SetActive(false);
            inActiveList.Add(activeList[index]);
            activeList.RemoveAt(index);
        }

    }

    private void ActivateIcon(List<GameObject> activeIcons, List<GameObject> inactiveIcons)
    {
        if (inactiveIcons.Count != 0)
        {
            int index = (int)UnityEngine.Random.Range(0, inactiveIcons.Count - 1);

            inactiveIcons[index].SetActive(true);

            activeIcons.Add(inactiveIcons[index]);

            inactiveIcons.RemoveAt(index);
        }
        else
            Debug.LogWarning("Inactive Icons lenght was 0 when we tried to activate an icon.");
    }
}
