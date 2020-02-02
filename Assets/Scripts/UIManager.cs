using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animation FadeInOut;
    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
    }

    public void FadeIn()
    {
        FadeInOut.Play("FadeIn");
    }
    public void FadeOut()
    {
        FadeInOut.Play("FadeOut");
    }
}
