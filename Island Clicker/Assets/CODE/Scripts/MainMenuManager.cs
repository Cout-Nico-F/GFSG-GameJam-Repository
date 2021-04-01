using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {

        ResetAll();
        AudioManager.instance.Play("MainMenu-Music");

    }
    public void Play()
    {
        AudioManager.instance.Stop("MainMenu-Music");
        AudioManager.instance.Play("NoStar-Music");
        AudioManager.instance.Play("Ambience");
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

        AudioSource[] allAudioSources;
        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (var asource in allAudioSources)
        {
            asource.Stop();
        }
    }
}
