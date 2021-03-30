using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int damage = 10;

    public int Damage { get => damage; }

    public void WoodUpgrade()
    {
        if (Stats.Wood >= 10)
        {
            Stats.Wood -= 10;
            damage = 30;
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
        if (Stats.Wood >= 30 && Stats.Rock >= 3)
        {
            Stats.Rock -= 3;
            Stats.Wood -= 30;
            damage = 60;
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
        if (Stats.Wood >= 5 && Stats.Rock >= 6 && Stats.Water >= 20)
        {
            Stats.Rock -= 3;
            Stats.Wood -= 30;
            Stats.Water -= 20;
            damage = 180;
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
        //upgrade damage
        damage = 540;
        //change sword-ui button

    }
    public void CrystalUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        damage = 1080;
        //change sword-ui button to maxed

    }

}
