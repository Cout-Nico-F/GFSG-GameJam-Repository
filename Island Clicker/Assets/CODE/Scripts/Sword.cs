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
    [SerializeField]
    private Animator woodSword, stoneSword, waterSword, holyWaterSword, crystalSword;

    
    public int Damage { get => damage; }

    private bool isGodSword;
    private int lastDamage;

    bool islevel0, islevel1, islevel2, islevel3, islevel4, islevel5;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
        islevel0 = true;
    }
    private void Update()
    {
        if (Stats.Wood > 10 && islevel0)
        {
            islevel0 = false;
            islevel1 = true;
            AudioManager.instance.Play("SwordLvlUpReady");
            //Sword ready animations
            woodSword.SetBool("isReady", true);
        }
        if (Stats.Wood >= 30 && Stats.Rock >= 8 && islevel1)
        {
            islevel1 = false;
            islevel2 = true;
            AudioManager.instance.Play("SwordLvlUpReady");
            stoneSword.SetBool("isReady", true);

        }
        if (Stats.Rock >= 8 && Stats.Wood >= 30 && Stats.Water >= 50 && islevel2)
        {
            islevel2 = false;
            islevel3 = true;
            AudioManager.instance.Play("SwordLvlUpReady");
            waterSword.SetBool("isReady", true);

        }
        if (Stats.Rock >= 16 && Stats.Wood >= 90 && Stats.Water >= 225 && islevel3)
        {
            islevel3 = false;
            islevel4 = true;
            AudioManager.instance.Play("SwordLvlUpReady");
            holyWaterSword.SetBool("isReady", true);

        }
        if (Stats.Water >= 150 && Stats.Crystal >= 6 && islevel4)
        {
            islevel4 = false;
            AudioManager.instance.Play("SwordLvlUpReady");
            crystalSword.SetBool("isReady", true);
        }
    }

    public void WoodUpgrade()
    {
        int woodAmount = 10;
        if (Stats.Wood >= woodAmount)
        {
            AudioManager.instance.Play("SwordWoodLvlUp");

            Stats.Wood -= woodAmount;
            damage = 30;
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            woodUpgradeUI.SetActive(false);
            stoneUpgradeUI.SetActive(true);
        }
        else
        {
            //mostrar ui durante X segundos
            AudioManager.instance.Play("Sword_Error");
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
            AudioManager.instance.Play("SwordRockLvlUp");


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
            AudioManager.instance.Play("Sword_Error");
            StartCoroutine(ShowMessageCoroutine(stoneRecipeUi, 1f));
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
            AudioManager.instance.Play("SwordWaterLvlUp");

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
            AudioManager.instance.Play("Sword_Error");
            StartCoroutine(ShowMessageCoroutine(waterRecipeUi, 2f));
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
            AudioManager.instance.Play("SwordHolyWaterLvlUp");

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
            AudioManager.instance.Play("Sword_Error");
            StartCoroutine(ShowMessageCoroutine(holyWaterRecipeUi, 3f));
            //Animation
        }
    }
    public void CrystalUpgrade()
    {
        int waterAmount = 150;
        int crystalAmount = 6;

        if (Stats.Crystal >= crystalAmount && Stats.Water >= waterAmount)
        {
            AudioManager.instance.Play("SwordCrystalLvlUp");

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
            AudioManager.instance.Play("Sword_Error");
            StartCoroutine(ShowMessageCoroutine(crystalRecipeUi, 3f));
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
