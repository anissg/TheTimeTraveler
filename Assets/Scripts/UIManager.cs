using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Animation FadeInOut;
    public VerticalLayoutGroup objects;
    public GameObject textObj;
    public TextMeshProUGUI textarea;
    public Image image;
    public string[] texts;
    public Sprite[] images;

    public int currentText = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1));
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            // Debug.Log("hello");
            textObj.SetActive(true);
            if(currentText < 11)
            SetText(currentText);
            if (Input.GetButtonDown("Jump"))
            {
                currentText++;
                if (currentText == texts.Length)
                {
                    
                    FadeInNextScene();
                }
                MusicManager.Instance.PlayUiSfx(currentText % 2);
            }
        }
        else
        {
            textObj.SetActive(false);
        }
    }

    public void FadeInNextScene()
    {
        StartCoroutine("NextScene");
    }

    public GameObject AddObject(GameObject obj)
    {
        return Instantiate(obj, objects.transform);
    }

    IEnumerator NextScene()
    {
        FadeIn();
        yield return  new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeIn()
    {
        FadeInOut.Play("FadeIn");
    }
    public void FadeOut()
    {
        FadeInOut.Play("FadeOut");
    }

    public void SetText(int i)
    {
        textarea.text = texts[i];
        image.sprite = images[i];
    }
}
