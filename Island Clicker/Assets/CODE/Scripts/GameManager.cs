using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Forest forest;
    //Mountain mountain;
    //River river;
    //Crystal crystal;


    private void Start()
    {
        forest = FindObjectOfType<Forest>();
        //mountain = FindObjectOfType<Mountain>();
        //river = FindObjectOfType<River>();
        //crystal = FindObjectOfType<Crystal>();

        //initialize the static references.
        StaticReference.Sword = FindObjectOfType<Sword>();
        StaticReference.Target = FindObjectOfType<House>().transform;
    }

    void Update()
    {
        UnlockResourcesByExperience();
    }

    private void UnlockResourcesByExperience()
    {
        
        //if (Stats.Score >= crystal.ActivationScore && crystal.ActiveFlag == false)
        //{
        //    crystal.Unlock();
        //}
        //else if (Stats.Score > river.ActivationScore && river.ActiveFlag == false)
        //{
        //    river.Unlock();
        //}
        //else if (Stats.Score > mountain.ActivationScore && mountain.ActiveFlag == false)
        //{
        //    mountain.Unlock();
        //}
        //else 
        if (Stats.Score > forest.ActivationScore && forest.ActiveFlag == false)
        {
            forest.Unlock();
        }
    }
}
