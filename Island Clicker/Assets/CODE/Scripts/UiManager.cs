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
    private int lastWood;
    private int multiplicator;

    private int woodAmmountPerIcon;
    private int rockAmmountPerIcon;
    private int waterAmmountPerIcon;
    private int crystalAmmountPerIcon;

    [SerializeField]
    private List<GameObject> woodIcons , rockIcons, waterIcons , CrystalIcons;
    private List<GameObject> woodIconsAll, rockIconsAll, waterIconsAll, CrystalIconsAll;


    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        multiplicator = 1;

        woodIconsAll = woodIcons;
        rockIconsAll = rockIcons;
        waterIconsAll = waterIcons;
        CrystalIconsAll = CrystalIcons;

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
                if (Stats.Wood >= woodAmmountPerIcon * multiplicator)
                {
                    multiplicator++;
                    PickOne(woodIcons);
                    //elegir un random de la lista
                    //borrar de la lista el gameobject ya activado
                }
                break;
            case GameManager.EnemyTypes.Rock:
                break;
            case GameManager.EnemyTypes.Water:
                break;
            case GameManager.EnemyTypes.Crystal:
                break;
            default:
                break;
        }
    }

    private void PickOne(List<GameObject> icons)
    {
        int index =(int) UnityEngine.Random.Range(0, icons.Count);
        icons[index].SetActive(true);
       // icons[index].
    }
}
