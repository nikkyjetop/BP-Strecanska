using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FullscreenEffects : MonoBehaviour
{
    public List<Material> ShaderMaterials = new List<Material>();
    public TMP_Dropdown ShaderDropdown;
    public GameObject CRTGlobalVolume;
    public TextMeshProUGUI CRTButtonText;


    private string _featureName = "FullScreenPassRendererFeature";
    private UniversalRenderPipelineAsset _universalRenderPipelineAsset;
    private FullScreenPassRendererFeature _feature;





    public void Start()
    {
        _universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
        _feature = _universalRenderPipelineAsset.rendererDataList[0].rendererFeatures
            .FirstOrDefault(f => f != null && f.name == _featureName) as FullScreenPassRendererFeature;

        ShaderDropdown.ClearOptions();
        ShaderDropdown.AddOptions(new List<string> { "Prázdný shader", "Shader poškození A", "Shader poškození B", "Shader zeminy", "Shader námrazy", "Shader magie", "Shader perly", "Shader kouøe" });
        _feature.passMaterial = ShaderMaterials[0];
    }

    public void ToggleCRTButtonClick()
    {
        if (CRTGlobalVolume.activeSelf)
        {
            CRTGlobalVolume.SetActive(false);
            CRTButtonText.text = "Zapnout CRT";
        }
        else
        {
            CRTGlobalVolume.SetActive(true);
            CRTButtonText.text = "Vypnout CRT";
        }
    }

    public void OnDropdownItemClick()
    {
        _feature.passMaterial = ShaderMaterials[ShaderDropdown.value];
    }

    public void BackButtonClick()
    {
        _feature.passMaterial = ShaderMaterials[0];

        SceneManager.LoadScene(0);
    }
}
