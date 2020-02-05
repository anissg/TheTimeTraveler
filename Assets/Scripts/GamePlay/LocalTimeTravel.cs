using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LocalTimeTravel : MonoBehaviour {
    [SerializeField] private GameObject shadowPresent;
    [SerializeField] private GameObject shadowPast;
    [SerializeField] private GameObject past;
    private TilemapRenderer[] pastTilemapRenderers;
    [SerializeField] private GameObject timeTravelShadow;
    [SerializeField] private GameObject shadow;

    void Start() {
        pastTilemapRenderers = past.GetComponentsInChildren<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            switch (TimeManager.GetInstance().era)
            {
                case Era.Present:
                    shadowPresent.SetActive(true);
                    shadowPast.SetActive(false);
                    shadow.SetActive(true);
                    timeTravelShadow.SetActive(true);
                    
                    foreach (var pastTilemapRenderer in pastTilemapRenderers)
                        pastTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    break;
                case Era.Past:
                    shadowPresent.SetActive(false);
                    shadowPast.SetActive(true);
                    shadow.SetActive(false);
                    timeTravelShadow.SetActive(false);
                    foreach (var pastTilemapRenderer in pastTilemapRenderers)
                        pastTilemapRenderer.maskInteraction = SpriteMaskInteraction.None;
                    break;
            }

            TimeManager.GetInstance().SwitchEra();
        }
    }
}