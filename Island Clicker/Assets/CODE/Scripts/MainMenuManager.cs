using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {

        ResetAll();

    }
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }
    private void ResetAll()
    {
        Stats.Crystal = 0;
        Stats.Rock = 0;
        Stats.Water = 0;
        Stats.Wood = 0;
        Stats.Experience = 0;

        StaticReference.GameManager = null;
        StaticReference.Sword = null;
        StaticReference.Target = null;

        Enemy.speedMultiplier = 1;
    }
}
