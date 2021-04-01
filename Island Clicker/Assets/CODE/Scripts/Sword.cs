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
    [Space]
    [SerializeField]
    private GameObject woodRecipeUi, stoneRecipeUi, waterRecipeUi, holyWaterRecipeUi, crystalRecipeUi;
    [Space]
    [SerializeField]
    private GameObject antennaRecipeUi;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
    }
    public int Damage { get => damage; }

    private bool isGodSword;
    private int lastDamage;
    public void WoodUpgrade()
    {
        int woodAmount = 10;
        if (Stats.Wood >= woodAmount)
        {
            Stats.Wood -= woodAmount;
            damage = 30;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            woodUpgradeUI.SetActive(false);
            stoneUpgradeUI.SetActive(true);
        }
        else
        {
            //mostrar ui durante X segundos
            StartCoroutine(ShowMessageCoroutine(woodRecipeUi, 0.75f));
            //Animation?
        }
    }
    public void StoneUpgrade()
    {
        int rockAmount = 8;
        int woodAmount = 30;
        if (Stats.Wood >= woodAmount && Stats.Rock >= rockAmount)
        {
            Stats.Rock -= rockAmount;
            Stats.Wood -= woodAmount;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, rockAmount);

            damage = 60;
            stoneUpgradeUI.SetActive(false);
            waterUpgradeUI.SetActive(true);
        }
        else
        {
            //you cant upgrade.
            ShowMessageCoroutine(stoneRecipeUi, 4f);
            //Animation
        }
    }
    public void WaterUpgrade()
    {
        int rockAmount = 8;
        int woodAmount = 30;
        int waterAmount = 50;

        if (Stats.Wood >= 30 && Stats.Rock >= 8 && Stats.Water >= 50)
        {
            Stats.Rock -= rockAmount;
            Stats.Wood -= woodAmount;
            Stats.Water -= waterAmount;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, rockAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, waterAmount);
            damage = 180;
            waterUpgradeUI.SetActive(false);
            holyWaterUpgradeUI.SetActive(true);

        }
        else
        {
            //you cant upgrade.
            ShowMessageCoroutine(waterRecipeUi, 6f);
            //Animation
        }
    }
    public void HolyWaterUpgrade()
    {
        int rockAmount = 16;
        int woodAmount = 90;
        int waterAmount = 225;
        //Check if you have the requisites
        if (Stats.Wood >= woodAmount && Stats.Rock >= rockAmount && Stats.Water >= waterAmount)
        {
            Stats.Wood -= woodAmount;
            Stats.Rock -= rockAmount;
            Stats.Water -= waterAmount;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, rockAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, waterAmount);
            damage = 540;
            holyWaterUpgradeUI.SetActive(false);
            crystalUpgradeUI.SetActive(true);

        }
        else
        {
            //you cant upgrade.
            ShowMessageCoroutine(holyWaterRecipeUi, 7f);
            //Animation
        }
    }
    public void CrystalUpgrade()
    {
        int waterAmount = 150;
        int crystalAmount = 6;

        if (Stats.Crystal >= crystalAmount && Stats.Water >= waterAmount)
        {
            Stats.Crystal -= crystalAmount;
            Stats.Water -= waterAmount;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Crystal, crystalAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, waterAmount);


            damage = 1080;
            holyWaterUpgradeUI.SetActive(false);
            crystalUpgradeUI.SetActive(true);
        }
        else
        {
            //you cant upgrade.
            ShowMessageCoroutine(crystalRecipeUi, 5f);
            //Animation
        }
    }

    public void GodSword()
    {
        if (!isGodSword)
        {
            lastDamage = damage;
            damage = 9999;
            isGodSword = true;
        }
        else
        {
            damage = lastDamage;
            isGodSword = false;
        }
    }
    IEnumerator ShowMessageCoroutine(GameObject recipeUi, float timeToShow)
    {
        // Show the ui
        recipeUi.SetActive(true);

        //Wait for X seconds
        yield return new WaitForSecondsRealtime(timeToShow);

        // Hide the ui
        recipeUi.SetActive(false);
    }
}
