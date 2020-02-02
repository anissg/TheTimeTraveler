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

    }

    // Update is called once per frame
    void PlayFx()
    {
        Instantiate(fxprefab).GetComponent<FxPlayer>().Play(clip);
        
    }


}
