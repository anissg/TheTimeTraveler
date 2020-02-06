using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.FadeOut();
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            MusicManager.Instance.SwitchMusic();
            MusicManager.Instance.SetTracks(0);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            MusicManager.Instance.SwitchMusic();
            MusicManager.Instance.SetTracks(1);
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
            MusicManager.Instance.SetTracks(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
