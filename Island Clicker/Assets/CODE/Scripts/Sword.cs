using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int damage = 10;

    [SerializeField]
    private UiManager uiManager;
    [SerializeField]
    private GameObject woodUpgradeUI, stoneUpgradeUI, waterUpgradeUI, holyWaterUpgradeUI, crystalUpgradeUI, maxedUpgradeUI;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
    }
    public int Damage { get => damage; }

    private bool isGodSword;
    private int lastDamage;
    public void WoodUpgrade()
    {
        if (Stats.Wood >= 10)
        {
            Stats.Wood -= 10;
            damage = 30;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, 10);
            woodUpgradeUI.SetActive(false);
            stoneUpgradeUI.SetActive(true);
        }
        else
        {
            //you cant upgrade.
            //Animation
        }
        //change sword-ui button
    }
    public void StoneUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        if (Stats.Wood >= 30 && Stats.Rock >= 4)
        {
            Stats.Rock -= 4;
            Stats.Wood -= 30;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, 30);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, 4);

            damage = 60;
            stoneUpgradeUI.SetActive(false);
            waterUpgradeUI.SetActive(true);
        }
        else
        {
            //you cant upgrade.
            //Animation
        }
        //change sword-ui button

    }
    public void WaterUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        if (Stats.Wood >= 30 && Stats.Rock >= 8 && Stats.Water >= 50)
        {
            Stats.Wood -= 30;
            Stats.Rock -= 8;
            Stats.Water -= 50;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, 30);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, 8);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, 50);
            damage = 180;
            waterUpgradeUI.SetActive(false);
            holyWaterUpgradeUI.SetActive(true);

        }
        else
        {
            //you cant upgrade.
            //Animation
        }
        //change sword-ui button

    }
    public void HolyWaterUpgrade()
    {
        //Check if you have the requisites
        if (Stats.Wood >= 100 && Stats.Rock >= 16 && Stats.Water >= 150)
        {
            Stats.Wood -= 100;
            Stats.Rock -= 16;
            Stats.Water -= 150;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, 100);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, 16);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, 150);
            damage = 540;
            holyWaterUpgradeUI.SetActive(false);
            crystalUpgradeUI.SetActive(true);

        }
        else
        {
            //you cant upgrade.
            //Animation
        }

    }
    public void CrystalUpgrade()
    {
        if (Stats.Crystal >= 6 && Stats.Water >= 150)
        {
            Stats.Crystal -= 6;
            Stats.Water -= 150;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Crystal, 6);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, 150);
            

            damage = 1080;
            holyWaterUpgradeUI.SetActive(false);
            crystalUpgradeUI.SetActive(true);
        }
        else
        {
            //you cant upgrade.
            //Animation
        }
    }

    public void GodSword()
    {
        if (!isGodSword)
        {
            lastDamage = damage;
            damage = 9999;
        }
        else damage = lastDamage;
    }

}
