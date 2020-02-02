using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animation FadeInOut;
    public VerticalLayoutGroup objects;
    // Start is called before the first frame update
    public void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject AddObject(GameObject obj)
    {
        return Instantiate(obj, objects.transform);
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
