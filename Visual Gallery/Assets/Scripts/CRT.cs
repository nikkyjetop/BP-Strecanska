using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CRT : MonoBehaviour
{
    public GameObject CRTGlobalVolume;
    public TextMeshProUGUI buttonText;
    public void ToggleCRTButtonClick()
    {

    }


    public void BackButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleCRTClick()
    {
        CRTGlobalVolume.SetActive(CRTGlobalVolume.activeSelf);
    }
}
