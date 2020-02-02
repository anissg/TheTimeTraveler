using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public int level = 1;               //Level to open after splash
    public float setTime = 3.0f;        //Duration before loading next level
    public float dimTime = 2.0f;        //Duration Before Staring to Fade or Dim Lights
    public float zoomSpeed = 0.2f;      //Speed at which camera zooms in

    private SpriteRenderer spriteRenderer;

    float timer;     // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0.0f; //Initializes Timer to 0
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //Adds Time.deltaTime to timer each update
        
        if (timer > dimTime && timer < setTime)
        {
            //spriteRenderer.
        }
        else if (timer > setTime) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}