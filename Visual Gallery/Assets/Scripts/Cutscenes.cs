using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour
{
    public TextMeshProUGUI PromptText;
    public Image Image;
    [SerializeField]
    public List<ImageWithPrompt> imageWithPrompts = new List<ImageWithPrompt>();


    private int _index = 0;


    public void OnStart()
    {
        Image.sprite = imageWithPrompts[_index].Image;
        PromptText.text = imageWithPrompts[_index].Prompt;
    }
    
    public void RightButtonClick()
    {
        _index++;
        if(_index >= imageWithPrompts.Count)
        {
            _index = 0;
        }
        Image.sprite = imageWithPrompts[_index].Image;
        PromptText.text = imageWithPrompts[_index].Prompt;
    }

    public void LeftButtonClick()
    {
        _index--;
        if (_index < 0)
        {
            _index = imageWithPrompts.Count - 1;
        }
        Image.sprite = imageWithPrompts[_index].Image;
        PromptText.text = imageWithPrompts[_index].Prompt;
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene(0);
    }

}

[Serializable]
public class ImageWithPrompt
{
    public Sprite Image;
    public string Prompt;
}
