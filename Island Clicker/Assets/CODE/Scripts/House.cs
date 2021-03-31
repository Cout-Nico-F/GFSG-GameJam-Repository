using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private int health = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
        //updateHealthUI;
        if (health <= 0)
        {
            Destroyed();
        }
    }
    private void Destroyed()
    {
        //Avisar al GM que la casa fue destruida
        //cambiar el sprite de la casa
        Debug.LogWarning("House has been destroyed!");
    }
}
