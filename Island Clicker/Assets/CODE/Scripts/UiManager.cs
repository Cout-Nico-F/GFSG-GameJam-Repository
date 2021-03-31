using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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


    TextMeshProUGUI tmp;
    private int woodMultiplicator, rockMultiplicator, waterMultiplicator, crystalMultiplicator;

    private int woodAmmountPerIcon = 10;
    private int rockAmmountPerIcon = 5;
    private int waterAmmountPerIcon;
    private int crystalAmmountPerIcon;

    [SerializeField]
    private List<GameObject> woodIcons , rockIcons, waterIcons , crystalIcons;
    private List<GameObject> woodIconsAll, rockIconsAll, waterIconsAll, crystalIconsAll;


    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        woodMultiplicator = 1;
        rockMultiplicator = 1;
        waterMultiplicator = 1;
        crystalMultiplicator = 1;

        woodIconsAll = woodIcons;
        rockIconsAll = rockIcons;
        waterIconsAll = waterIcons;
        crystalIconsAll = crystalIcons;

    }
    
    public void UpdateText()
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
                if (Stats.Wood >= woodAmmountPerIcon * woodMultiplicator)
                {
                    woodMultiplicator++;
                    PickOne(woodIcons);
                }
                break;
            case GameManager.EnemyTypes.Rock:
                if (Stats.Rock >= rockAmmountPerIcon * rockMultiplicator)
                {
                    rockMultiplicator++;
                    PickOne(rockIcons);
                }
                break;
            case GameManager.EnemyTypes.Water:
                if (Stats.Water >= waterAmmountPerIcon * waterMultiplicator)
                {
                    waterMultiplicator++;
                    PickOne(waterIcons);
                }
                break;
            case GameManager.EnemyTypes.Crystal:
                if (Stats.Crystal >= crystalAmmountPerIcon * crystalMultiplicator)
                {
                    crystalMultiplicator++;
                    PickOne(crystalIcons);
                }
                break;
            default:
                break;
        }
    }

    private void PickOne(List<GameObject> icons)
    {
        int index =(int) UnityEngine.Random.Range(0, icons.Count);
        icons[index].SetActive(true);
        icons.RemoveAt(index);
    }
}
