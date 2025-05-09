using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelObjects : MonoBehaviour
{
    public Animator Animator;
    public Button IdleButton;
    public Button RunButton;
    public Button JumpButton;
    public TextMeshProUGUI LeavesButtonText;
    public TextMeshProUGUI SnowButtonText;

    public GameObject LeavesParticles;
    public GameObject SnowParticles;


    public void RunButtonClick()
    {
        IdleButton.interactable = true;
        RunButton.interactable = false;

        Animator.SetBool("IsRunning", true);
    }

    public void IdleButtonClick()
    {
        IdleButton.interactable = false;
        RunButton.interactable = true;

        Animator.SetBool("IsRunning", false);

    }

    public void JumpButtonClick()
    {
        Animator.SetBool("IsGrounded", false);

        IdleButton.interactable = false;
        RunButton.interactable = false;
        StartCoroutine(JumpCoroutine());
    }

    public void ToggleLeavesClick()
    {
        if(LeavesParticles.activeSelf)
        {
            LeavesParticles.SetActive(false);
            LeavesButtonText.text = "Zapnout listí";
        }
        else
        {
            LeavesParticles.SetActive(true);
            LeavesButtonText.text = "Vypnout listí";
        }   
    }

    public void ToggleSnowClick()
    {
        if (SnowParticles.activeSelf)
        {
            SnowParticles.SetActive(false);
            SnowButtonText.text = "Zapnout sníh";
        }
        else
        {
            SnowParticles.SetActive(true);
            SnowButtonText.text = "Vypnout sníh";
        }
    }

    private IEnumerator JumpCoroutine()
    {
        Animator.SetFloat("VerticalVelocity", 5);
        yield return new WaitForSeconds(1);
        Animator.SetFloat("VerticalVelocity", 0);
        yield return new WaitForSeconds(0.5f);
        Animator.SetFloat("VerticalVelocity", -5);
        yield return new WaitForSeconds(1);
        Animator.SetFloat("VerticalVelocity", 0);
        Animator.SetBool("IsGrounded", true);

        if(Animator.GetBool("IsRunning"))
        {
            IdleButton.interactable = true;
            RunButton.interactable = false;
        }
        else
        {
            IdleButton.interactable = false;
            RunButton.interactable = true;
        }
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
