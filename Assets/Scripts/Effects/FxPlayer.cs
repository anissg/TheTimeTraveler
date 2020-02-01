using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxPlayer : MonoBehaviour
{
    #region Public Properties
    public AudioSource audioSource;
    private bool play = false;

    #endregion
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        play = true;
    }

    private void Update()
    {
        if (!audioSource.isPlaying  && play)
        { 
            Destroy(gameObject);
        }
    }


}
