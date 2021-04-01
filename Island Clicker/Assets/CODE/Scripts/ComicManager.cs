using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicManager : MonoBehaviour
{
    public void PlayGame()
    {
        AudioManager.instance.Stop("Comic-Music");

        AudioManager.instance.Play("NoStar-Music");
        AudioManager.instance.Play("Ambience");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }
}
