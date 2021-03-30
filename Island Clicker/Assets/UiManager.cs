using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    TextMeshProUGUI tmp;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdateText()
    {
        tmp.text = "Experience: " + Stats.Experience;
    }

}
