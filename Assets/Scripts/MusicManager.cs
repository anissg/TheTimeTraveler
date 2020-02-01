using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioMixerGroup pastMixer;
    public AudioMixerGroup presentMixer;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

    public void MixerVolume(float vol)
    {
        pastMixer.audioMixer.SetFloat("PastVolume", vol);
        presentMixer.audioMixer.SetFloat("PresentVolume", Mathf.Abs(vol)-80f);
    }
}
