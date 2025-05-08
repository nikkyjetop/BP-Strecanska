using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public Image image;
    [SerializeField]
    public List<ImageWithPrompt> imageWithPrompts = new List<ImageWithPrompt>();


    private int _index = 0;


    public void OnStart()
    {

    }
    
    public void RightButtonClick()
    {

    }

    public void LeftButtonClick()
    {

    }

    private string[] prompts = { 
        "ahoj"
    };
}

[Serializable]
public class ImageWithPrompt
{
    public Sprite Image;
    public string Prompt;
}
