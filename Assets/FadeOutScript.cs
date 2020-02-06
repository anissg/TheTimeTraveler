using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutScript : MonoBehaviour
{
    public int MusicToPlay;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.FadeOut();
        if (MusicManager.Instance.CurrentTrack != MusicToPlay)
        {
            MusicManager.Instance.SwitchMusic();
            MusicManager.Instance.SetTracks(MusicToPlay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
