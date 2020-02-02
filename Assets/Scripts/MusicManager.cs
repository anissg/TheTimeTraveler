using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [Header("Past")]
    public AudioMixerGroup pastMixer;
    public AudioSource pastAudio;
    public AudioClip[] pastClips;
    [Header("Present")]
    public AudioMixerGroup presentMixer;
    public AudioSource presentAudio;
    public AudioClip[] presentClips;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

    public void SwitchMusic()
    {
        float pVol;
        pVol = TimeManager.GetInstance().era == Era.Past ? 0 : -80;
        pastMixer.audioMixer.SetFloat("PastVolume",pVol );
        presentMixer.audioMixer.SetFloat("PresentVolume", -80 - pVol);
    }

    public void SetTracks(int i)
    {
        StartCoroutine(SetTracksRoutine(i));
    }

    IEnumerator SetTracksRoutine(int i)
    {
        pastAudio.DOFade(0, 1);
        presentAudio.DOFade(0, 1);
        yield return new WaitForSeconds(1f);
        pastAudio.clip = pastClips[i];
        presentAudio.clip = presentClips[i];
        pastAudio.DOFade(1, 1);
        presentAudio.DOFade(1, 1);

    }
}
