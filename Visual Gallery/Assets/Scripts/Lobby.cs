using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public Image image;
    [SerializeField]
    public List<ImageWithTitle> imageWithTitleList = new List<ImageWithTitle>();


    private int _index = 0;


    public void OnStart()
    {
        image.sprite = imageWithTitleList[_index].Image;
        titleText.text = imageWithTitleList[_index].Title;
    }

    public void RightButtonClick()
    {
        _index++;
        if (_index >= imageWithTitleList.Count)
        {
            _index = 0;
        }
        image.sprite = imageWithTitleList[_index].Image;
        titleText.text = imageWithTitleList[_index].Title;
    }

    public void LeftButtonClick()
    {
        _index--;
        if (_index < 0)
        {
            _index = imageWithTitleList.Count - 1;
        }
        image.sprite = imageWithTitleList[_index].Image;
        titleText.text = imageWithTitleList[_index].Title;
    }



    public void BackButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}

[Serializable]
public class ImageWithTitle
{
    public Sprite Image;
    public string Title;
}
