using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AudioClip clip;
    public GameObject fxprefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayFx",0,5);
        InvokeRepeating("Past", 0,10);
        InvokeRepeating("Present", 5,10);
    }

    // Update is called once per frame
    void PlayFx()
    {
        Instantiate(fxprefab).GetComponent<FxPlayer>().Play(clip);
        
    }

    void Past()
    {
        MusicManager.Instance.MixerVolume(0);
    }

    void Present()
    {
        MusicManager.Instance.MixerVolume(-80);
    }
}
