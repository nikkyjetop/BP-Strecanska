using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCracker : MonoBehaviour
{
    public SeasonsManager SeasonsManager;
    public Button CrackButton;

    private SpriteRenderer _spriteRenderer;
    private MaterialPropertyBlock _propertyBlock;
    private SeasonMaterialController _seasonMaterialController;
    private CrackState _crackState;
    private float _resetTime = 5;
    public enum CrackState
    {
        None,
        One,
        Two,
        Three
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _propertyBlock = new MaterialPropertyBlock();
        _seasonMaterialController = GetComponent<SeasonMaterialController>();
    }

    private void Start()
    {
        SetCrackLevel(1f, 1f);
        _crackState = CrackState.None;
    }


    private void SetCrackLevel(float edgeMin, float edgeMax)
    {
        _spriteRenderer.GetPropertyBlock(_propertyBlock);

        _propertyBlock.SetFloat("_CrackEdgeMin", edgeMin);
        _propertyBlock.SetFloat("_CrackEdgeMax", edgeMax);

        _spriteRenderer.SetPropertyBlock(_propertyBlock);
    }

    public void Crack()
    {
        switch (_crackState)
        {
            case CrackState.None:
                _crackState = CrackState.One;
                SetCrackLevel(0.2f, 0);
                break;
            case CrackState.One:
                _crackState = CrackState.Two;
                SetCrackLevel(0.5f, 0.1f);
                break;
            case CrackState.Two:
                _crackState = CrackState.Three;
                SetCrackLevel(0.7f, 0.1f);
                break;
            case CrackState.Three:
                _crackState = CrackState.Three;
                StartCoroutine(HandleBreak());
                break;
        }
    }

    private IEnumerator HandleBreak()
    {
        _spriteRenderer.enabled = false;
        CrackButton.interactable = false;

        int random = Random.Range(1, 3);

        yield return new WaitForSeconds(_resetTime);
        _seasonMaterialController.SwitchToSeason(SeasonsManager.CurrentSeason);
        _spriteRenderer.enabled = true;
        CrackButton.interactable = true;
        _crackState = CrackState.None;
        SetCrackLevel(1f, 1f);
    }
}
