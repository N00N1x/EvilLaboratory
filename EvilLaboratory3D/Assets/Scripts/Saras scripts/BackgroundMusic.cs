using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public Button toggleButton; 
    public AudioSource audioSource;  
    public AudioSource clickButtonSFX;

    void Start()
    {
        if (audioSource.clip == null)
        {
            Debug.LogError("AudioSource does not have an AudioClip assigned!");
            return;
        }

        audioSource.Play();
        Debug.Log("Music playing initially. Audio isPlaying: " + audioSource.isPlaying);

        toggleButton.onClick.AddListener(ToggleSound);
    }


    private void OnBuyChildrenButtonClick()
    {
        clickButtonSFX.Play();
    }
    void ToggleSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();  
            Debug.Log("Music paused");  
        }
        else
        {
            audioSource.UnPause(); 
            Debug.Log("Music playing");  
        }

        Debug.Log("ToggleSound executed. Audio isPlaying: " + audioSource.isPlaying);
    }
}

