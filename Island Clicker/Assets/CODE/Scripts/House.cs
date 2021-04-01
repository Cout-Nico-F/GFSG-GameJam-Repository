using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private int health = 6;
    private UiManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>().OnHouseTouch(); //Enemies destroyed on contact.

        health--;
        uiManager.UpdateHealth(health);

        string[] audioNames = { "HouseAttacked1", "HouseAttacked2", "HouseAttacked3" , "HouseAttacked4" , "HouseAttacked5" };
        int index = UnityEngine.Random.Range(0, audioNames.Length);
        AudioManager.instance.Play(audioNames[index]);

        if (health <= 0)
        {
            Destroyed();
        }
    }
    private void Destroyed()
    {
        //Avisar al GM que la casa fue destruida
        StaticReference.GameManager.HouseDestroyed();
        AudioManager.instance.Play("HouseDestroyed");
        StaticReference.GameManager.HealthGodMode();//prevent damage sound to keep playing.
        Debug.LogWarning("House has been destroyed!");
    }
}
