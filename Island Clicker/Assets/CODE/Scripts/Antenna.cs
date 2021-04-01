using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    UiManager uiManager;
    [SerializeField]
    GameObject antennaRecipeUi;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
    }
    public void FixAntenna()
    {
        int waterAmount = 175;
        int crystalAmount = 16;
        int rockAmount = 24;
        int woodAmount = 90;

        if (Stats.Crystal >= crystalAmount && Stats.Water >= waterAmount && Stats.Rock >= rockAmount && Stats.Wood >= woodAmount)
        {
            Stats.Crystal -= crystalAmount;
            Stats.Water -= waterAmount;
            Stats.Wood -= woodAmount;
            Stats.Water -= waterAmount;

            uiManager.SpentMaterials(GameManager.EnemyTypes.Crystal, crystalAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Water, waterAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Wood, woodAmount);
            uiManager.SpentMaterials(GameManager.EnemyTypes.Rock, rockAmount);

            AudioManager.instance.Stop("CrystalStar-Music");
            AudioManager.instance.Play("AntennaBuild");
            AudioManager.instance.Play("Victory");
            StaticReference.GameManager.WinGame();
        }
        else
        {
            AudioManager.instance.Play("Sword_Error");
            StartCoroutine(
                        ShowMessageCoroutine(antennaRecipeUi, 2f));
            //Animation
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
