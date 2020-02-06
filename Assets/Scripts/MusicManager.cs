using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using System;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [Header("Present")]
    public AudioMixerGroup presentMixer;
    public AudioSource presentAudio;
    public AudioClip[] presentClips;
    [Header("SFX")]
    public AudioSource sfxAudioSource;



    public AudioClip[] footStepsClips;
    public AudioClip[] ladderClips;
    public AudioClip[] uiClips;
    public AudioClip[] deathClips;
    public AudioClip[] leverClips;
    public AudioClip[] doorClips;
    public AudioClip[] powerClips;
    [Header("Ui clips")]
    public AudioClip[] UiClips;

    public int CurrentTrack { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void Start()
    {
        SetTracks(0);
    }
    public void SwitchMusic()
    {
        //float pVol;
        //pVol = TimeManager.GetInstance().era == Era.Past ? 0 : -80;
        //pastMixer.audioMixer.SetFloat("PastVolume",pVol );
        //presentMixer.audioMixer.SetFloat("PresentVolume", -80 - pVol);
        //presentMixer.audioMixer.SetFloat("PresentVolume", -80 - pVol);
    }

    public void SetTracks(int i)
    {
        StartCoroutine(SetTracksRoutine(i));
        CurrentTrack = i;
    }

    IEnumerator SetTracksRoutine(int i)
    {
        //pastAudio.DOFade(0, .25);
        presentAudio.DOFade(0, .25f);
        yield return new WaitForSeconds(.25f);
        //pastAudio.clip = pastClips[i];
        presentAudio.clip = presentClips[i];
        //pastAudio.Play();
        presentAudio.Play();
        //pastAudio.DOFade(1, 1);
        presentAudio.DOFade(1, .25f);

    }
    internal void PlayUiSfx(int v)
    {
        sfxAudioSource.clip = uiClips[v];
        sfxAudioSource.Play();
    }
}
