using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int damage = 10;

    public int Damage { get => damage; }

    public void WoodUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        damage = 30;
        //change sword-ui button
    }
    public void StoneUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        damage = 60;
        //change sword-ui button

    }
    public void WaterUpgrade()
    {
        //Check if you have the requisites
        //upgrade damage
        damage = 180;
        //change sword-ui button

    }
    public void ExperienceUpgrade()
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
